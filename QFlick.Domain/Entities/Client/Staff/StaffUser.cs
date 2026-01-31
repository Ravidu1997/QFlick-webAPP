using QFlick.Domain.Entities.Client.Business;
using QFlick.Domain.Primitives;

namespace QFlick.Domain.Entities.Client.Staff
{
    public class StaffUser : Entity
    {
        public string Email { get; set; } = string.Empty!;
        public string Name { get; set; } = string.Empty!;
        public string Business { get; set; } = string.Empty!;
        public required BusinessLocation BusinessLocation { get; set; }
        public bool IsActive { get; set; } 
        public DateTime CreatedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
    }
}
