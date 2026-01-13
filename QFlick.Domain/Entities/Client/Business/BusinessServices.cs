using QFlick.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QFlick.Domain.Entities.Client.Business
{
    public class BusinessServices : Entity
    {
        public string BusinessName { get; set; } = string.Empty!;
        public int CategoryId { get; set; }
        public string BusinessEmail { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty!;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DeletetAt { get; set; }

    }
}
