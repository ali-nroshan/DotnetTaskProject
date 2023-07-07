using Microsoft.EntityFrameworkCore;
using Project.Application.Contracts.Persistence;
using Project.Infrastructure.Persistence.Context;

namespace Project.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
	{
		private readonly ProjectDbContext _context;

        public UserRepository(ProjectDbContext context)
        {
            _context = context;
        }

		public async Task<Guid?> CheckUserCredentialsAsync(string username, string passwordHash)
		{
			var result = await _context.Users.SingleOrDefaultAsync(q => q.PasswordHash == passwordHash && q.UserName == username);
			return result?.UserId;
		}

		public async Task<bool> UserIdExistAsync(Guid userId)
		{
			return await _context.Users.AnyAsync(q => q.UserId == userId);
		}
	}
}
