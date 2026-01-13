using QFlick.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QFlick.Domain.Entities.Common
{
    public class AppRolePermissions : Entity
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
    }
}
