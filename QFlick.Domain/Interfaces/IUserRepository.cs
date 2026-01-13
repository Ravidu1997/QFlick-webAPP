using QFlick.Domain.Entities.Client.User;
using QFlick.Domain.Entities.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QFlick.Domain.Interfaces
{
    public interface IUserRepository : IGenericRepository<AppUser>
    {
        Task<List<QueueDetail>> GetUsersByQueueId(int queueId);
        Task<AppUser> GetUserDetail(string uid);
    }
}
