using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;

namespace Project.Infrastructure.Persistence.Configurations.Entities
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
	{
        public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasData(
				new User
				{
					UserId = Guid.NewGuid(),
					UserName = "user1",
					PasswordHash = "sW7X0ks+y9QWTc2tN04IwKt1GKoH+dNoPzTCs8Z6FYMCaMtKVsH/b1TI5Up5X1uHwIZotR+C0Ak/e67n0pgRgQ=="
				},
				new User
				{
					UserId = Guid.NewGuid(),
					UserName = "user2",
					PasswordHash = "bSAb7u+1ibCO8GctrII1PQy9mtmeFkLIOhYB89ZHvMoAMle16PMb3B1z++yE+whcedbiZ3t/+SfoI6VOeJFA2Q=="
				});
		}
	}
}
