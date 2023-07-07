using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.Authentication.Requests.Queries;
using Project.Application.Models.Identity;

namespace Project.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		private readonly IMediator _mediator;
        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST api/<AuthenticationController>
        [HttpPost]
		public async Task<ActionResult<string>> Post([FromBody] AuthenticationRequestModel authenticationRequestModel)
		{
			if (ModelState.IsValid)
			{
				var request = new AuthenticationRequest { AuthenticationRequestModel = authenticationRequestModel };
			 	string token = await _mediator.Send(request);
				return Ok(token);
			}

			return BadRequest();
		}
	}
}
