# Copilot Instructions for Chirper

This is a Twitter/X-like social media API built with ASP.NET Core 8 Minimal APIs, following **Vertical Slice Architecture (VSA)**.

## Build, Test, and Run

### Build and run
```bash
dotnet build src/Chirper.csproj
dotnet run --project src/Chirper.csproj
```

### Database migrations
```bash
# From src directory
dotnet ef migrations add <MigrationName>
dotnet ef database update
```

### Docker
```bash
docker build -t chirper .
docker run -p 8080:80 chirper
```

## Architecture

### Vertical Slice Architecture
Code is organized by **features**, not technical layers. Each feature/slice is self-contained under its domain folder:
- `Authentication/Endpoints/` - Login, Signup
- `Posts/Endpoints/` - CreatePost, UpdatePost, DeletePost, LikePost, etc.
- `Comments/Endpoints/` - CreateComment, LikeComment, etc.
- `Users/Endpoints/` - FollowUser, GetUserPosts, etc.

Each endpoint is independent and can use any approach that fits its needs (different from traditional layered architecture where all features share the same layers).

### Endpoint Pattern
Every endpoint implements `IEndpoint` with a static `Map` method:

```csharp
public class CreatePost : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app
        .MapPost("/", Handle)
        .WithSummary("Creates a new post")
        .WithRequestValidation<Request>();

    public record Request(string Title, string? Content);
    public record Response(int Id);
    
    public class RequestValidator : AbstractValidator<Request> { }
    
    private static async Task<Ok<Response>> Handle(Request request, AppDbContext database, ...) { }
}
```

**Key characteristics:**
- Each endpoint defines its own `Request`/`Response` contracts (no shared DTOs)
- Validators are nested classes using FluentValidation
- Handler method uses dependency injection via parameters
- All endpoint registration happens in `Endpoints.cs` via `.MapEndpoint<TEndpoint>()`

### Data Model Philosophy
Data types are **simple data containers with no business logic** (anemic domain model):
- Properties for data only
- No methods or behavior
- Located in `Data/Types/`
- Use `IEntity` interface for common properties (Id)
- Use `IOwnedEntity` for entities with a UserId

Business logic lives in endpoint handlers, not in domain objects.

### Database Access
- **No repository pattern** - EF Core `AppDbContext` is injected directly into handlers
- If EF Core isn't suitable for a specific feature, other approaches (e.g., Dapper) can be used independently per slice

### Common Functionality

#### Endpoint Filters
Located in `Common/Api/Filters/`:
- `RequestValidationFilter<TRequest>` - Automatic FluentValidation
- `EnsureEntityExistsFilter<TRequest, TEntity>` - Validates entity exists by ID
- `EnsureUserOwnsEntityFilter<TRequest, TEntity>` - Validates user owns entity
- `RequestLoggingFilter` - Logs all requests

Applied via extension methods in `Common/Api/Extensions/RouteHandlerBuilderValidationExtensions.cs`:
```csharp
.WithRequestValidation<Request>()
.WithEnsureEntityExists<Post, Request>(r => r.PostId)
.WithEnsureUserOwnsEntity<Post, Request>(r => r.PostId)
```

#### Authentication
- JWT-based authentication configured in `ConfigureServices.cs`
- Use `ClaimsPrincipal.GetUserId()` extension method to get authenticated user ID
- Public endpoints use `.MapPublicGroup()`, protected use `.MapAuthorizedGroup()`

## Conventions

### Adding New Endpoints
1. Create endpoint class under appropriate domain folder (e.g., `Posts/Endpoints/NewEndpoint.cs`)
2. Implement `IEndpoint` interface with static `Map` method
3. Define nested `Request`, `Response`, and `RequestValidator` classes
4. Add endpoint registration in `Endpoints.cs` under the appropriate `Map*Endpoints` method
5. Use `.MapPublicGroup()` for anonymous access or `.MapAuthorizedGroup()` for authenticated

### Request/Response DTOs
- Always create separate DTOs per endpoint, even if similar to existing ones
- Nest `Request` and `Response` records inside the endpoint class
- This prevents coupling and allows each endpoint to evolve independently

### Validation
- Use FluentValidation for all request validation
- Nest validator class inside endpoint: `public class RequestValidator : AbstractValidator<Request>`
- Apply with `.WithRequestValidation<Request>()` extension method

### Global Usings
Common namespaces are globally imported in `Program.cs`:
- `Chirper.Common.Api`
- `Chirper.Data`
- `FluentValidation`
- `Microsoft.EntityFrameworkCore`
- And others - check `Program.cs` for the full list

### Configuration
Application setup is split into two files:
- `ConfigureServices.cs` - Service registration (database, auth, logging, validation)
- `ConfigureApp.cs` - Middleware pipeline configuration
- Both are called from `Program.cs`
