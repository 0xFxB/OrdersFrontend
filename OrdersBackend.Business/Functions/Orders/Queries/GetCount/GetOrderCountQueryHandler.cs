using MediatR;
using OrdersBackend.Shared.Entities;
using OrdersBackend.Shared.Functions.Orders;
using OrdersBackend.Shared.Interfaces.Repositories;

namespace OrdersBackend.Business.Functions.Orders.Queries;

public class GetOrderCountQueryHandler : IRequestHandler<GetOrderCountQuery, int>
{
    private readonly IRepository<Order> repository;

    public GetOrderCountQueryHandler(IRepository<Order> repository)
    {
        this.repository = repository;
    }

    public async Task<int> Handle(GetOrderCountQuery request, CancellationToken cancellationToken)
    {
        var count = await repository.GetTotalCount();
        return count;
    }
}
