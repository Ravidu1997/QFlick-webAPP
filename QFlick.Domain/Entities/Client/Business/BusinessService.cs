using QFlick.Domain.Primitives;

namespace QFlick.Domain.Entities.Client.Business
{
    public class BusinessService: Entity
    {
        public string Name { get; set; } = string.Empty!;
        public ICollection<BusinessLocation> BusinessLocations { get; set; } = [];
        public bool IsAvailableAtAllLocation { get; set; }
        public TimeOnly Duration { get; set; }
        
    }
}
