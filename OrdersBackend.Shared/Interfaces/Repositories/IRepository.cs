using OrdersBackend.Shared.Dto.Repository;

namespace OrdersBackend.Shared.Interfaces.Repositories;

public interface IRepository<T> where T : class
{
    public Task<int> AddAsync(T entity);
    public Task<int> UpdateAsync(T entity);
    public Task<int> DeleteAsync(T entity);
    public Task<T> GetByIdAsync(int id, Func<IQueryable<T>, IQueryable<T>>? func = null);
    public Task<IEnumerable<T>> GetAllAsync(RepositoryGetAllFilterDto<T> filters);
    public Task<int> GetTotalCount();
}
