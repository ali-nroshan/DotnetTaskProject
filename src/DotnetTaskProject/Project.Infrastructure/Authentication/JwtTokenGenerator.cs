using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Project.Application.Contracts.Infrastructure;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Project.Infrastructure.Authentication
{
	public class JwtTokenGenerator : IJwtTokenGenerator
	{
		private readonly JwtSettings _jwtSettings;

        public JwtTokenGenerator(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public string GenerateToken(Guid userId)
		{
			var signingCredentials = new SigningCredentials(
				new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
				SecurityAlgorithms.HmacSha256);

			var claims = new[]
			{
				new Claim("userid", userId.ToString())
			};

			var token = new JwtSecurityToken(
				issuer: _jwtSettings.Issuer,
				audience: _jwtSettings.Audience,
				claims: claims,
				expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
				signingCredentials: signingCredentials);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}