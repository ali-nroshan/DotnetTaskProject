using System.ComponentModel.DataAnnotations;

namespace Project.Application.Models.Identity
{
	public class AuthenticationRequestModel
	{
		[Required]
		[MaxLength(100)]
		[MinLength(3)]
        public string UserName { get; set; }

		[Required]
		[MaxLength(50)]
		[MinLength(5)]
		public string Password { get; set; }
    }
}
