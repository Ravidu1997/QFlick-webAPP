using QFlick.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QFlick.Domain.Entities.Client.Staff
{
    public class KnowledgeBase : Entity
    {
        public string Title { get; set; } = string.Empty!;
        public string? Description { get; set; }
        public List<Step> Steps { get; set; } = [];
        public int ServiceId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
    public class Step
    {
        public string Name { get; set; } = string.Empty!;
    }
}
