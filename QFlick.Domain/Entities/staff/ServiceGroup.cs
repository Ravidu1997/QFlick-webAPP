using QFlick.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QFlick.Domain.Entities.staff
{
    public class ServiceGroup: Entity
    {
        public string GroupName { get; set; } = string.Empty!;
    }
}
