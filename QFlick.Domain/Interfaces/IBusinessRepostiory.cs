using QFlick.Domain.Entities.Client.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QFlick.Domain.Interfaces
{
    public interface IBusinessRepostiory : IGenericRepository<BusinessServices>
    {
        Task<bool> IsOwnBusiness(string userId, int businessId);
    }
}
