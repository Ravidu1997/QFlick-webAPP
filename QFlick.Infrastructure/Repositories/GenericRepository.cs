using Microsoft.EntityFrameworkCore;
using QFlick.Domain.Interfaces;
using QFlick.Infrastructure.Persistence;
using System.Linq.Expressions;

namespace QFlick.Infrastructure.Repositories
{
    public class GenericRepository<T>(AppDbContext context) : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context = context;

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Set<T>().ToListAsync<T>(cancellationToken);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken)
        {
            return await _context.Set<T>().Where(expression).ToListAsync(cancellationToken);
        }

        public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Set<T>().FindAsync(id, cancellationToken);
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken)
        {
            _context.Set<T>().Add(entity);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            _context.Set<T>().Update(entity);
            await Task.CompletedTask;
        }
        public async Task DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            _context.Set<T>().Remove(entity);
            await Task.CompletedTask;
        }
    }
}
