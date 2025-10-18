using QFlick.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QFlick.Domain.Entities.Client
{
    public class User: Entity
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = null!;
        public string? UserPassword { get; set; }
        public bool? IsVerified { get; set; }
        public bool? IsActive { get; set; }
        public int QueueStatus { get; set; } 
        public int LoyaltyPoints { get; set; } = 0;
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifeidAt { get; set; }
        public DateTime? DeletedAt { get; set; } 
    }
}
