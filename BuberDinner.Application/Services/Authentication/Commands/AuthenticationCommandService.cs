﻿using BuberDinner.Application.Interfaces.Authentication;
using BuberDinner.Application.Interfaces.Persistence;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;
using ErrorOr;

namespace BuberDinner.Application.Services.Authentication.Commands;
public class AuthenticationCommandService : IAuthenticationCommandService
{
    private readonly IUserRepository _userRepository;

    public AuthenticationCommandService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        var user = new User { Email = email, FirstName = firstName, LastName = lastName, Password = password };

        _userRepository.Add(user);

        return new AuthenticationResult(user, "token");
    }
}
