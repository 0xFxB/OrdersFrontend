using MediatR;
using Microsoft.EntityFrameworkCore;
using OrdersBackend.Shared.Entities;
using OrdersBackend.Shared.Functions.Orders.Queries;
using OrdersBackend.Shared.Interfaces.Repositories;

namespace OrdersBackend.Business.Functions.Orders.Queries;

public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<OrderDto>>
{
    private readonly IRepository<Order> repository;

    public GetAllOrdersQueryHandler(IRepository<Order> repository)
    {
        this.repository = repository;
    }

    public async Task<IEnumerable<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        var orderEntities = await repository.GetAllAsync(new() { Page = request.Page, Func = x => x.Include(y => y.OrderLines), PageSize = 10 });
        var orderDtos = orderEntities.Select(MapTo);
        return orderDtos;
    }

    private OrderDto MapTo(Order order)
        => new(order.Id, order.CreateDate, order.Status, order.ClientName, order.OrderPrice);
}
