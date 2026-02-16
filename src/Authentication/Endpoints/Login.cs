using Chirper.Authentication.Services;

namespace Chirper.Authentication.Endpoints;

public class Login : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app
        .MapPost("/login", Handle)
        .WithSummary("Logs in a user")
        .WithRequestValidation<Request>();

    public record Request(string Username, string Password);
    public record Response(string AccessToken, string RefreshToken);
    public class RequestValidator : AbstractValidator<Request>
    {
        public RequestValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }

    private static async Task<Results<Ok<Response>, UnauthorizedHttpResult>> Handle(Request request, AppDbContext database, Jwt jwt, CancellationToken cancellationToken)
    {
        var user = await database.Users
            .SingleOrDefaultAsync(x => x.Username == request.Username, cancellationToken);

        if (user is null || !user.VerifyPassword(request.Password))
        {
            return TypedResults.Unauthorized();
        }

        var accessToken = jwt.GenerateToken(user);
        var refreshToken = new RefreshToken
        {
            Token = Jwt.GenerateRefreshToken(),
            UserId = user.Id,
            ExpiresAtUtc = DateTime.UtcNow.Add(SecurityConstants.RefreshTokenLifetime)
        };
        await database.RefreshTokens.AddAsync(refreshToken, cancellationToken);
        await database.SaveChangesAsync(cancellationToken);

        var response = new Response(accessToken, refreshToken.Token);
        return TypedResults.Ok(response);
    }
}
