namespace Project.Infrastructure.Authentication
{
    public class JwtSettings
	{
        public string Secret { get; init; }
        public string Issuer { get; init; }
        public string Audience { get; init; }
        public int DurationInMinutes { get; init; }
    }
}
