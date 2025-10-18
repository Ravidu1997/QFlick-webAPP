using QFlick.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QFlick.Domain.Entities.Client
{
    public class UserSetting: Entity
    {
        public DateTime? PasswordUpdatedAt { get; set; }

    }
}
