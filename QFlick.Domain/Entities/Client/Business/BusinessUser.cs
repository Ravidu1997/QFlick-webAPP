using QFlick.Domain.Primitives;

namespace QFlick.Domain.Entities.Client.Business
{
    public class BusinessUser: Entity
    {
        public string UId { get; set; } = string.Empty;
        public required string BusinessName { get; set; }
        public required string BusinessEmail { get; set; }
        public required int CategoryId { get; set; }
        public string Address { get; set; } = string.Empty;
        public required string City { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public required bool IsAdmin { get; set; } 
        public  int ServicesCompleted { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeleatedAt { get; set; }
    }
}
