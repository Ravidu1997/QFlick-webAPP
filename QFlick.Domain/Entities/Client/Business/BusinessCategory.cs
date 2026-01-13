using QFlick.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QFlick.Domain.Entities.Client.Business
{
    public class BusinessCategory : Entity
    {
        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; } = string.Empty;
    }
}
