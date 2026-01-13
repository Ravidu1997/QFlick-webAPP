using QFlick.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QFlick.Domain.Entities.Common
{
    public class AppMenuItem : Entity
    {
        public required string Path { get; set; }
        public required string Title { get; set; }
        public int PermissionId { get; set; }

    }
}
