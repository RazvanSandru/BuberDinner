using BuberDinner.Domain.Entities;
using BuberDinner.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Interfaces.Persistence;

namespace BuberDinner.Application.Authentication.Queries.Login;
public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
	private readonly IUserRepository _userRepository;

	public LoginQueryHandler(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}

	public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
	{
		if (_userRepository.GetUserByEmail(query.Email) is not User user)
		{
			return Errors.Authentication.InvalidCredentials;
		}

		if (user.Password != query.Password)
		{
			return Errors.Authentication.InvalidCredentials;
		}

		return new AuthenticationResult(user, "token");
	}
}
