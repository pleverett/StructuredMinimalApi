using Chirper.Authentication.Services;

namespace Chirper.Authentication.Endpoints;

public class RefreshTokenEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app
        .MapPost("/refresh", Handle)
        .WithSummary("Refreshes an access token using a refresh token")
        .WithRequestValidation<Request>();

    public record Request(string RefreshToken);
    public record Response(string AccessToken, string RefreshToken);
    public class RequestValidator : AbstractValidator<Request>
    {
        public RequestValidator()
        {
            RuleFor(x => x.RefreshToken).NotEmpty();
        }
    }

    private static async Task<Results<Ok<Response>, UnauthorizedHttpResult>> Handle(
        Request request, 
        AppDbContext database, 
        Jwt jwt, 
        CancellationToken cancellationToken)
    {
        var refreshToken = await database.RefreshTokens
            .Include(x => x.User)
            .SingleOrDefaultAsync(x => x.Token == request.RefreshToken, cancellationToken);

        if (refreshToken is null || !refreshToken.IsActive)
        {
            return TypedResults.Unauthorized();
        }

        // Revoke the old refresh token
        refreshToken.RevokedAtUtc = DateTime.UtcNow;

        // Generate new tokens
        var newAccessToken = jwt.GenerateToken(refreshToken.User);
        var newRefreshToken = new RefreshToken
        {
            Token = Jwt.GenerateRefreshToken(),
            UserId = refreshToken.UserId,
            ExpiresAtUtc = DateTime.UtcNow.Add(SecurityConstants.RefreshTokenLifetime)
        };

        await database.RefreshTokens.AddAsync(newRefreshToken, cancellationToken);
        await database.SaveChangesAsync(cancellationToken);

        var response = new Response(newAccessToken, newRefreshToken.Token);
        return TypedResults.Ok(response);
    }
}
