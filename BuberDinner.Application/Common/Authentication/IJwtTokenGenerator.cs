namespace BuberDinner.Application.Common.Authentication;
public interface IJwtTokenGenerator
{
    string GenerateToken(Guid Id, string FirstName, string LastName);
}