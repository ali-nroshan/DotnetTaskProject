using MediatR;
using Project.Application.Contracts.Infrastructure;
using Project.Application.Contracts.Persistence;
using Project.Application.Exceptions;
using Project.Application.Features.Authentication.Requests.Queries;

namespace Project.Application.Features.Authentication.Handlers.Queries
{
    public class AuthenticationRequestHandler : IRequestHandler<
		AuthenticationRequest, string>
	{
		private readonly IUserRepository _userRepository;
		private readonly IJwtTokenGenerator _jwtTokenGenerator;
		private readonly IPasswordHasher _passwordHasher;

        public AuthenticationRequestHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
			_jwtTokenGenerator = jwtTokenGenerator;
			_passwordHasher = passwordHasher;
        }

        public async Task<string> Handle(AuthenticationRequest request, CancellationToken cancellationToken)
		{
			string passwordHash = _passwordHasher.HashPassword(request.AuthenticationRequestModel.Password);
			var userId = await _userRepository.CheckUserCredentialsAsync(request.AuthenticationRequestModel.UserName, passwordHash);
			if (userId == null)
				throw new UnauthorizedException();

			string token = _jwtTokenGenerator.GenerateToken(userId.Value);
			return token;
        }
	}
}
