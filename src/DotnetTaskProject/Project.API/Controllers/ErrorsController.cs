using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Exceptions;

namespace Project.API.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
	[ApiController]
	public class ErrorsController : ControllerBase
	{
		[Route("/Error")]
		public ActionResult ErrorHandler()
		{
			Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

			switch (exception)
			{
				case BadRequestException: return BadRequest();
				case NotFoundException: return NotFound();
				case UnauthorizedException: return Unauthorized();
				default: return StatusCode(500);
			}
		}
	}
}
