using MediatR;
using Project.Application.Models.Identity;

namespace Project.Application.Features.Authentication.Requests.Queries
{
    public class AuthenticationRequest : IRequest<string>
	{
        public AuthenticationRequestModel AuthenticationRequestModel { get; set; }
    }
}
