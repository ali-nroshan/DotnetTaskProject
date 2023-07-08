using Microsoft.Extensions.DependencyInjection;
using Project.Infrastructure.Persistence.Context;

namespace Project.Infrastructure.Persistence.Configurations;

public static class DatabaseConfigurations
{
    public static void InitialDatabase(this IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ProjectDbContext>();
            context.Database.EnsureCreated();
        }
    }
}