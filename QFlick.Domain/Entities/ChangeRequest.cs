using QFlick.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QFlick.Domain.Entities
{
    public class ChangeRequest: Entity
    {
        public string Name { get; set; } = string.Empty!;
        public string Description { get; set; } = string.Empty!;
        public string Type { get; set; } = string.Empty!;
        public int CreatedBy { get; set; }
        public int ClosedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
