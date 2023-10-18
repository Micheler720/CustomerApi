namespace Customers.Api.Models
{
    public interface IRepository<T> 
        where T : Entity
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task SaveChangesAsync();
    }
}