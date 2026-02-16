using Chirper.Authentication.Services;

namespace Chirper.Authentication.Endpoints;

public class Signup : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app
        .MapPost("/signup", Handle)
        .WithSummary("Creates a new user account")
        .WithRequestValidation<Request>();

    public record Request(string Username, string Password, string Name);
    public record Response(string AccessToken, string RefreshToken);
    public class RequestValidator : AbstractValidator<Request>
    {
        public RequestValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50);
            
            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(8)
                .WithMessage("Password must be at least 8 characters long");
            
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);
        }
    }

    private static async Task<Results<Ok<Response>, ValidationError>> Handle(Request request, AppDbContext database, Jwt jwt, CancellationToken cancellationToken)
    {
        var isUsernameTaken = await database.Users
            .AnyAsync(x => x.Username == request.Username, cancellationToken);

        if (isUsernameTaken)
        {
            return new ValidationError("Username is already taken");
        }

        var user = new User
        {
            Username = request.Username,
            PasswordHash = User.HashPassword(request.Password),
            DisplayName = request.Name
        };
        await database.Users.AddAsync(user, cancellationToken);
        await database.SaveChangesAsync(cancellationToken);

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