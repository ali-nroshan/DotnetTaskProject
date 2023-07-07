namespace Project.Application.Contracts.Persistence
{
    public interface IUserRepository
	{
		Task<bool> UserIdExistAsync(Guid userId);

		Task<Guid?> CheckUserCredentialsAsync(string username, string passwordHash);
	}
}
