using Microsoft.EntityFrameworkCore;
using QFlick.Domain.Entities.Client.Business;
using QFlick.Domain.Interfaces;
using QFlick.Infrastructure.Persistence;

namespace QFlick.Infrastructure.Repositories
{
    public class BusinessRepostiory(AppDbContext context) : GenericRepository<BusinessServices>(context), IBusinessRepostiory
    {
        private readonly AppDbContext _context = context;

        public async Task<bool> IsOwnBusiness(string userId, int businessId)
        {
            return await _context.Business
                .AsNoTracking()
                .AnyAsync(b => b.UserId == userId && b.Id == businessId);
        }
    }
}
