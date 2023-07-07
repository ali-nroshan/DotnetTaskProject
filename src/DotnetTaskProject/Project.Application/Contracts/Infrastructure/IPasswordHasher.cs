namespace Project.Application.Contracts.Infrastructure
{
    public interface IPasswordHasher
	{
		string HashPassword(string password);
	}
}
