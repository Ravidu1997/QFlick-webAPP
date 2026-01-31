using Microsoft.EntityFrameworkCore;
using QFlick.Domain.Entities.Client.Business;
using QFlick.Domain.Interfaces;
using QFlick.Infrastructure.Persistence;

namespace QFlick.Infrastructure.Repositories
{
    public class BusinessRepostiory(AppDbContext context) : GenericRepository<BusinessUser>(context), IBusinessRepostiory
    {
        private readonly AppDbContext _context = context;

        public async Task<bool> IsOwnBusiness(string userId, int businessId)
        {
            return await _context.BusinessUser
                .AsNoTracking()
                .AnyAsync(b => b.UId == userId && b.Id == businessId);
        }
    }
}
