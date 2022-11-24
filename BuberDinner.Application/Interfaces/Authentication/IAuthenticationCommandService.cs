using BuberDinner.Application.Services.Authentication.Common;
using ErrorOr;

namespace BuberDinner.Application.Interfaces.Authentication;
public interface IAuthenticationCommandService
{
    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
}
