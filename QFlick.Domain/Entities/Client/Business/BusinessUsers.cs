using QFlick.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QFlick.Domain.Entities.Client.Business
{
    public class BusinessUsers : Entity
    {
        public string UId { get; set; } = string.Empty;
        public int? BusinessId { get; set; }
        public string Name { get; set; } = string.Empty;
        public required string Email { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsAdmin { get; set; } = true;
        public int ServicesCompleted { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeleatedAt { get; set; }
    }
}
