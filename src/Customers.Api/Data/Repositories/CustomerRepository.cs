using Customers.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Customers.Api.Data.Repositories
{
    public class CustomerRepository : Repository<Customer>, IRepository<Customer>
    {
        public CustomerRepository(CustomerContext context)
        : base(context)
        {
            
        }

        public override async Task<Customer?> GetByIdAsync(Guid id)
        {
            return await _context.Customers
                .AsNoTracking()
                .Include(c => c.Address)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
        }

        public override async Task<IEnumerable<Customer>> GetAllAsync()
        {            
            return await _context.Customers
                .AsNoTracking()
                .Include(c => c.Address)
                .ToListAsync();
        }

    }
}