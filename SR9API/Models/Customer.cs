using System;
using System.ComponentModel.DataAnnotations;

namespace SR9API.Models
{
    public class Customer
    {
        [Key]
        public Guid CustomerId { get; set; }
        [Required(ErrorMessage ="Customer name field is required")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        public DateTime? DateBirth { get; set; }
        [Phone]
        [MaxLength(10)]
        public string Phone { get; set; }
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
    }
}
