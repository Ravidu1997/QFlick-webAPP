using QFlick.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QFlick.Domain.Entities
{
    public class Setting: Entity
    {
        public string Title { get; set; }  = string.Empty!;
        public string Code { get; set; } = string.Empty!;
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}
