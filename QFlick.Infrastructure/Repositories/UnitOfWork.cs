using Microsoft.EntityFrameworkCore.Storage;
using QFlick.Domain.Entities.Client.Business;
using QFlick.Domain.Interfaces;
using QFlick.Infrastructure.Persistence;

namespace QFlick.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IDbContextTransaction? _transaction;

        public IUserRepository UserRepo { get; }
        public IBusinessRepostiory BusinessRepo { get; }
        public IGenericRepository<BusinessUser> BusinessUserRepo { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            UserRepo = new UserRepository(context);
            BusinessRepo = new BusinessRepostiory(context);
            BusinessUserRepo = new GenericRepository<BusinessUser>(context);
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("Cannot commit without an active transaction!");
            }
            try
            {
                await _transaction.CommitAsync();
            }
            catch (Exception)
            {

                await _transaction.RollbackAsync();
                throw;
            }
            finally
            {
                await _transaction.DisposeAsync();
            }
        }


        public async Task RollbackAsync()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("No any transaction to rollback!");
            }
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }
    }
}
