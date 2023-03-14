using MediatR;
using Microsoft.EntityFrameworkCore;
using OrdersBackend.Shared.Entities;
using OrdersBackend.Shared.Functions.Orders.Queries;
using OrdersBackend.Shared.Interfaces.Repositories;

namespace OrdersBackend.Business.Functions.Orders.Queries;

public class GetOrderDetailsQueryHandler : IRequestHandler<GetOrderDetailsQuery, OrderDetailsDto>
{
    private readonly IRepository<Order> repository;

    public GetOrderDetailsQueryHandler(IRepository<Order> repository)
    {
        this.repository = repository;
    }

    public async Task<OrderDetailsDto> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
    {
        var order = await repository.GetByIdAsync(request.Id, x => x.Include(y => y.OrderLines));
        var dto = MapTo(order);
        return dto;
    }

    private OrderDetailsDto MapTo(Order order)
        => new(order.Id, order.ClientName, order.CreateDate, order.OrderPrice, order.AdditionalInfo, order.Status, order.OrderLines.Select(MapTo));

    private OrderDetailsProductDto MapTo(OrderLine line)
        => new(line.Id ,line.Product, line.Price);
}
