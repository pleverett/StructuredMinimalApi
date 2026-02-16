using Microsoft.AspNetCore.Identity;

namespace Chirper.Data.Types;

public class User : IEntity
{
    private static readonly PasswordHasher<User> PasswordHasher = new();

    public int Id { get; private init; }
    public Guid ReferenceId { get; private init; } = Guid.NewGuid();
    public required string Username { get; set; }
    public required string PasswordHash { get; set; }
    public required string DisplayName { get; set; }
    public DateTime CreatedAtUtc { get; private init; } = DateTime.UtcNow;
    public List<Post> Posts { get; init; } = [];
    public List<PostLike> LikedPosts { get; init; } = [];
    public List<Comment> Comments { get; init; } = [];
    public List<CommentLike> LikedComments { get; init; } = [];
    public List<Follow> Following { get; init; } = [];
    public List<Follow> Followers { get; init; } = [];

    /// <summary>
    /// Hashes a password using ASP.NET Core Identity's PasswordHasher.
    /// </summary>
    public static string HashPassword(string password)
    {
        return PasswordHasher.HashPassword(null!, password);
    }

    /// <summary>
    /// Verifies a password against the stored hash.
    /// </summary>
    public bool VerifyPassword(string password)
    {
        var result = PasswordHasher.VerifyHashedPassword(this, PasswordHash, password);
        return result == PasswordVerificationResult.Success;
    }
}

public class Follow
{
    public required int FollowerUserId { get; init; }
    public User FollowerUser { get; init; } = null!;

    public required int FollowedUserId { get; init; }
    public User FollowedUser { get; init; } = null!;

    public DateTime CreatedAtUtc { get; private init; } = DateTime.UtcNow;
}