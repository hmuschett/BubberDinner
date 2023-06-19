using BuberDinner.Application.Common.Authentication;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Register(string FirstName, string LastName, string Email, string Password)
    {
        var userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId, FirstName, LastName);

        return new AuthenticationResult(
            userId,
            FirstName,
            LastName,
            Email,
            token
        );
    }

    public AuthenticationResult Login(string Email, string Password)
    {
         return new AuthenticationResult(
            Guid.NewGuid(),
            "FirstName",
            "LastName",
            Email,
            "Token"
        );
    }
}