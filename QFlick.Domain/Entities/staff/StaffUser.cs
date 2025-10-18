using QFlick.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QFlick.Domain.Entities.staff
{
    public class StaffUser: Entity
    {
        public string StaffName { get; set; } = string.Empty;
        public string Section {  get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public int ServicesCompleted { get; set; }
        public int ServiceGroupId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeleatedAt { get; set; }
    }
}
