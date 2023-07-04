using Microsoft.Extensions.DependencyInjection;
using Project.Application.Profiles;
using System.Reflection;


namespace Project.Application
{
	public static class DependencyContainer
	{
		public static IServiceCollection RegisterApplicationDependency (this IServiceCollection services)
		{
			services.AddAutoMapper(typeof(AutoMapperProfile));
			services.AddMediatR(mediatR =>
			{
				mediatR.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
			});
			return services;
		}
	}
}