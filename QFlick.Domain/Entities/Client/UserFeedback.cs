using QFlick.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QFlick.Domain.Entities.Client
{
    public class UserFeedback: Entity
    {
        public int UserId { get; set; }
        public string Titile {  get; set; } = string.Empty!;
        public int Rate { get; set; }
    }
}
