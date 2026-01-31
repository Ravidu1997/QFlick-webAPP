using Microsoft.EntityFrameworkCore;
using QFlick.Domain.Entities.Client.User;
using QFlick.Domain.Entities.Queue;
using QFlick.Domain.Interfaces;
using QFlick.Infrastructure.Persistence;

namespace QFlick.Infrastructure.Repositories
{
    public class UserRepository(AppDbContext context) : GenericRepository<AppUser>(context), IUserRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<List<QueueDetail>> GetUsersByQueueId(int queueId)
        {
            return await _context.QueueDetail
                .Where(p => p.Id == queueId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<AppUser> GetUserDetail(string uid)
        {
            return await _context.AppUser
                .Where(u => u.UId == uid)
                .FirstAsync();
        }
    }
}
