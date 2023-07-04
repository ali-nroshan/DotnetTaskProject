using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Domain.Entities
{
  public class Product
  {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string ManufactureEmail { get; set; }

        [Required]
        [Phone]
        [MaxLength(20)]
        public string ManufacturePhone { get; set; }

        [Required]
        public DateTime ProductDate { get; set; }

        public bool IsAvailable { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}