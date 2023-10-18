using Customers.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Customers.Api.Data.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : Entity
    {
        protected readonly CustomerContext _context;

        public Repository(CustomerContext context)
        {
           _context = context; 
        }
        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync<T>(e => e.Id == id);
        }

        public async Task SaveChangesAsync()
        {
           await _context.SaveChangesAsync(); 
        }

        
    }
}