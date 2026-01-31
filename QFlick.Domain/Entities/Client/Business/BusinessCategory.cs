using QFlick.Domain.Primitives;
using System.ComponentModel.DataAnnotations;

namespace QFlick.Domain.Entities.Client.Business
{
    public class BusinessCategory : Entity
    {
        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; } = string.Empty;
    }
}
