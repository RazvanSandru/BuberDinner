using BuberDinner.Domain.Entities;
using BuberDinner.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Interfaces.Persistence;

namespace BuberDinner.Application.Authentication.Commands.Register;
public class RegisterCommandHandler : 
	IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
	private readonly IUserRepository _userRepository;

	public RegisterCommandHandler(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}

	public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
	{
		if (_userRepository.GetUserByEmail(command.Email) is not null)
		{
			return Errors.User.DuplicateEmail;
		}

		var user = new User { Email = command.Email, FirstName = command.FirstName, LastName = command.LastName, Password = command.Password };

		_userRepository.Add(user);

		return new AuthenticationResult(user, "token");
	}
}
