using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;

namespace Chirper.Authentication.Services;

public class JwtOptions
{
    public required string Key { get; init; }
}

public static class SecurityConstants
{
    public static readonly TimeSpan AccessTokenLifetime = TimeSpan.FromMinutes(15);
    public static readonly TimeSpan RefreshTokenLifetime = TimeSpan.FromDays(7);
}

public class Jwt(IOptions<JwtOptions> options)
{
    public string GenerateToken(User user)
    {
        var key = SecurityKey(options.Value.Key);
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
        
        var token = new JwtSecurityToken
        (
            claims: [new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())],
            signingCredentials: new(key, SecurityAlgorithms.HmacSha256Signature),
            expires: DateTime.UtcNow.Add(SecurityConstants.AccessTokenLifetime)
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public static string GenerateRefreshToken()
    {
        var randomBytes = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomBytes);
        return Convert.ToBase64String(randomBytes);
    }

    public static SymmetricSecurityKey SecurityKey(string key) => new(Encoding.ASCII.GetBytes(key));
}