namespace Chirper.Data.Types;

public class RefreshToken
{
    public int Id { get; private init; }
    public required string Token { get; init; }
    public required int UserId { get; init; }
    public User User { get; init; } = null!;
    public DateTime CreatedAtUtc { get; private init; } = DateTime.UtcNow;
    public DateTime ExpiresAtUtc { get; init; }
    public DateTime? RevokedAtUtc { get; set; }
    public bool IsExpired => DateTime.UtcNow >= ExpiresAtUtc;
    public bool IsRevoked => RevokedAtUtc.HasValue;
    public bool IsActive => !IsRevoked && !IsExpired;
}
