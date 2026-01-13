using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QFlick.Domain.DTOs.Business
{
    public class CreateBusinessInputDto
    {
        public required string BusinessName { get; set; }
        public required int CategoryId { get; set; }
        public required string BusinessEmail { get; set; }
        public required string UserId { get; set; }
    }
}
