using System.ComponentModel.DataAnnotations;

namespace Project.Domain.Entities
{
  public class User
  {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(86)]
        [MinLength(86)]
        public string PasswordHash { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}