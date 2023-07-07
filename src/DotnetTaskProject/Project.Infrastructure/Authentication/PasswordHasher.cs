using Project.Application.Contracts.Infrastructure;
using System.Security.Cryptography;
using System.Text;

namespace Project.Infrastructure.Authentication
{
	public class PasswordHasher : IPasswordHasher
	{
		public string HashPassword(string password)
		{
			using (SHA512 sha512 = SHA512.Create())
			{
				var hashBytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(password));
				return Convert.ToBase64String(hashBytes);
			}
		}
	}
}
