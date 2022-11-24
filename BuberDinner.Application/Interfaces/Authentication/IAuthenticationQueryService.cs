using BuberDinner.Application.Services.Authentication.Common;
using ErrorOr;

namespace BuberDinner.Application.Interfaces.Authentication;
internal interface IAuthenticationQueryService
{
    public ErrorOr<AuthenticationResult> Login(string email, string password);
}
