using QFlick.Domain.Entities.Client.Staff;
using QFlick.Domain.Primitives;

namespace QFlick.Domain.Entities.Client.Business
{
    public class BusinessLocation: Entity
    {
        public int BusinessId { get; set; } 
        public string LocationName { get; set; } = string.Empty!;
        public string Address { get; set; } = string.Empty!;
        public string Status { get; set; }  = string.Empty!;
        public TimeOnly OpenedAt { get; set; } 
        public TimeOnly ClosedAt { get; set; }
        public ICollection<StaffUser> Staff {  get; set; } = [];
        public bool IsPrimary { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
