using Microsoft.EntityFrameworkCore;
using OrdersBackend.Shared.Dto.Repository;
using OrdersBackend.Shared.Entities;
using OrdersBackend.Shared.Interfaces.Repositories;
using System.Linq;

namespace OrdersBackend.Data;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly OrdersDbContext dbContext;

    public Repository(OrdersDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<int> AddAsync(T entity)
    {
        await dbContext.Set<T>().AddAsync(entity);
        var resultCount = await dbContext.SaveChangesAsync();
        return resultCount;
    }

    public async Task<int> DeleteAsync(T entity)
    {
        dbContext.Set<T>().Remove(entity);
        var resultCount = await dbContext.SaveChangesAsync();
        return resultCount;
    }

    public async Task<IEnumerable<T>> GetAllAsync(RepositoryGetAllFilterDto<T> filters)
    { 
        IQueryable<T> query = dbContext.Set<T>()
            .AsNoTracking();

        if(filters.Page.HasValue && filters.PageSize.HasValue)
            query = query.Skip((filters.Page.Value - 1) * filters.PageSize.Value).Take(filters.PageSize.Value);

        if(filters.Func is not null)
        {
            query = filters.Func(query);
        }

        var entities = await query.ToListAsync();

        return entities;
    }

    public async Task<T> GetByIdAsync(int id, Func<IQueryable<T>, IQueryable<T>>? func = null)
    {
        IQueryable<T> query = dbContext.Set<T>()
            .AsNoTracking();

        if (func is not null)
        {
            query = func(query);
        }

        var entity = await query.FirstOrDefaultAsync(x => (x as IEntity)!.Id == id);

        if (entity is null)
            throw new NullReferenceException(nameof(entity));

        return entity!;
    }

    public Task<int> GetTotalCount()
    {
        var count = dbContext.Set<T>().Count();
        return Task.FromResult(count);
    }

    public async Task<int> UpdateAsync(T entity)
    {
        var existingEntity = await dbContext.Set<T>().FindAsync((entity as IEntity)!.Id);

        if (existingEntity == null)
            throw new NullReferenceException();

        dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
        return await dbContext.SaveChangesAsync();
    }
}
