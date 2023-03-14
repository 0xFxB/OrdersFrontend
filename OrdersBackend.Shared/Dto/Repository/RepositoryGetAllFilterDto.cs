namespace OrdersBackend.Shared.Dto.Repository;

public class RepositoryGetAllFilterDto<T> where T : class
{
    public Func<IQueryable<T>, IQueryable<T>>? Func { get; set; } = null;
    public int? Page { get; set; } = null;
    public int? PageSize { get; set; } = null;
}
