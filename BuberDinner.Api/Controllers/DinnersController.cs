using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;
[Route("[controller]")]
public class DinnersController : ApiController
{
	[HttpGet]
	public IActionResult GetDinner()
	{
		return Ok();
	}
}
