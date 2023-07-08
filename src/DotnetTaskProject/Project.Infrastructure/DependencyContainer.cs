using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Project.Application.Contracts.Infrastructure;
using Project.Application.Contracts.Persistence;
using Project.Infrastructure.Authentication;
using Project.Infrastructure.Persistence.Context;
using Project.Infrastructure.Persistence.Repositories;
using System.Text;

namespace Project.Infrastructure
{
	public static class DependencyContainer
	{
		public static IServiceCollection RegisterInfrastructureDependency(this IServiceCollection services, IConfiguration configuration)
		{
			#region Persistence
			services.AddDbContext<ProjectDbContext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("ProjectDbContext"));
			});

			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<IUserRepository, UserRepository>();
			#endregion
			#region Infrastructure
			services.AddSingleton<IPasswordHasher, PasswordHasher>();

			services.Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));
			services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

			var jwtSettings = new JwtSettings();
			configuration.Bind(nameof(JwtSettings), jwtSettings);

			services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.TokenValidationParameters = new TokenValidationParameters()
					{
						ValidateIssuer = true,
						ValidateAudience = true,
						ValidateLifetime = true,
						ValidateIssuerSigningKey = true,
						ValidAlgorithms = new[] { SecurityAlgorithms.HmacSha256 },
						ValidIssuer = jwtSettings.Issuer,
						ValidAudience = jwtSettings.Audience,
						IssuerSigningKey = new SymmetricSecurityKey(
							Encoding.UTF8.GetBytes(jwtSettings.Secret))
					};
				});
			#endregion
			return services;
		}
	}
}
