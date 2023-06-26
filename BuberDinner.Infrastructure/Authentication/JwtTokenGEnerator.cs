using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BuberDinner.Application.Common.Authentication;
using Microsoft.IdentityModel.Tokens;
using BuberDinner.Application.Common.Services;

namespace BuberDinner.Infrastructure.Authentication;
public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    string IJwtTokenGenerator.GenerateToken(Guid userId, string FirstName, string LastName)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("super-secret-key-strong-extra-heavy")
            ),
            SecurityAlgorithms.HmacSha256
        );
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, LastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        var securityToken = new JwtSecurityToken(
            issuer: "BuberDiner",
            claims: claims,
            expires: _dateTimeProvider.UtcNow.AddMinutes(60),
            signingCredentials: signingCredentials
        );
        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}