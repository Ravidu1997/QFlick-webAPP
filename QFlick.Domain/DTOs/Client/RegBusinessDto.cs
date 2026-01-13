using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QFlick.Domain.DTOs.Client
{
    public class RegBusinessDto
    {
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string City { get; set; }
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
        [Required]
        public required string PhoneNumber { get; set; }
    }
}
