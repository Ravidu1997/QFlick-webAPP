using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QFlick.Domain.DTOs.Auth
{
    public class LoginInputDto
    {
        public string Email { get; set; } = string.Empty;
        public bool IsBusinessLogin { get; set; } = false;
        public bool IsSignFromGoogle { get; set; } = false;
    }
}
