using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QFlick.Domain.DTOs
{
    public class AppUserDto
    {
        public string? Name { get; set; }
        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public bool IsVerified { get; set; } = false;
        public bool IsActive { get; set; } = true;
    }
}
