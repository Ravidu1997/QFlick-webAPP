using QFlick.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QFlick.Domain.Entities.Common
{
    public class AppPermissions : Entity
    {
        public required string Code { get; set; }
        public string? Description { get; set; }
    }
}
