using QFlick.Domain.DTOs.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QFlick.Application.Abstractions
{
    public interface IBusinessService
    {
        Task<bool> IsOwnBusiness(string userId, int newBusinessId);

        Task CreateBusiness(CreateBusinessInputDto businessData, CancellationToken cancellationToken);
    }
}
