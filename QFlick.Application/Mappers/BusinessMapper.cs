using QFlick.Domain.DTOs.Business;
using QFlick.Domain.Entities.Client.Business;
using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QFlick.Application.Mappers
{
    [Mapper]
    public partial class BusinessMapper
    {
        [MapperIgnoreTarget(nameof(BusinessServices.Id))]
        [MapperIgnoreTarget(nameof(BusinessServices.IsActive))]
        [MapperIgnoreTarget(nameof(BusinessServices.CreatedAt))]
        [MapperIgnoreTarget(nameof(BusinessServices.DeletetAt))]
        public partial BusinessServices CreateBusinessDtoToBusinessServices(CreateBusinessInputDto business);

    }
}
