﻿using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BuberDinner.Api.Controllers;

[ApiController]
public class ApiController : ControllerBase
{
	protected IActionResult Problem(List<Error> errors)
	{
		if (errors.Count is 0)
		{
			return Problem();
		}

		if (errors.All(error => error.Type == ErrorType.Validation))
		{
			return CreateValidationProblem(errors);
		}

		var firstError = errors.FirstOrDefault();

		return CreateProblem(firstError);
	}

	private IActionResult CreateProblem(Error error)
	{
		var statusCode = error.Type switch
		{
			ErrorType.Conflict => StatusCodes.Status409Conflict,
			ErrorType.Validation => StatusCodes.Status400BadRequest,
			ErrorType.NotFound => StatusCodes.Status404NotFound,
			_ => StatusCodes.Status500InternalServerError
		};

		return Problem(statusCode: statusCode, title: error.Description);
	}

	private IActionResult CreateValidationProblem(List<Error> errors)
	{
		var modelStateDictionary = new ModelStateDictionary();

		foreach (var error in errors)
		{
			modelStateDictionary.AddModelError(error.Code, error.Description);
		}

		return ValidationProblem(modelStateDictionary);
	}
}
