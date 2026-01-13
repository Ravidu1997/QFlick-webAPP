using QFlick.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QFlick.Domain.Entities.Common
{
    public class AppRole : Entity
    {
        public string Name { get; set; } = string.Empty!;
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}
