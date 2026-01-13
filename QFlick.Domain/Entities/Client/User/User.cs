using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QFlick.Domain.Entities.Client.User
{
    public class AppUser : IdentityUser<int>
    {
        public string UId { get; set; } = string.Empty;
        public string? Name { get; set; }
        public bool IsActive { get; set; } = true;
        public string? QueueStatus { get; set; }
        //public int LoyaltyPoints { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ModifeidAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
