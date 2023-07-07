namespace Project.Application.Contracts.Infrastructure
{
    public interface IJwtTokenGenerator
	{
		string GenerateToken(Guid userId);
	}
}
