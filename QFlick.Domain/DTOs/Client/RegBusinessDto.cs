using System.ComponentModel.DataAnnotations;

namespace QFlick.Domain.DTOs.Client
{
    public class BusinessRegisterDto
    {
        [Required]
        public required string BusinessName { get; set; }

        [Required]
        [EmailAddress]
        public required string BusinessEmail { get; set; }

        [Required]
        public required int CategoryId { get; set; }

        [Required]
        public required string PhoneNumber { get; set; }

        public required string Address { get; set; } 

        [Required]
        public required string City { get; set; }

        [Required]
        public required string Password { get; set; }

        public required bool IsAdmin { get; set; }

        }
   }
