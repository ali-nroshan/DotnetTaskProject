using System.ComponentModel.DataAnnotations;

namespace Project.Domain.Entities
{
	public class User
	{
		[Key]
		public Guid UserId { get; set; }

		[Required]
		[MaxLength(100)]
		[MinLength(3)]
		public string UserName { get; set; }

		[Required]
		[MaxLength(100)]
        public string PasswordHash { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
