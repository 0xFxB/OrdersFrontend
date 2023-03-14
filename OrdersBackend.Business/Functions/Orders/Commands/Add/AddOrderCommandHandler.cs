using MediatR;
using OrdersBackend.Shared.Entities;
using OrdersBackend.Shared.Functions.Orders.Commands;
using OrdersBackend.Shared.Interfaces.Repositories;

namespace OrdersBackend.Business.Functions.Orders.Commands;

public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, int>
{
    private readonly IRepository<Order> repository;

    public AddOrderCommandHandler(IRepository<Order> repository)
    {
        this.repository = repository;
    }

    public async Task<int> Handle(AddOrderCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Order.clientName) || request.Order.products.Any(x => string.IsNullOrEmpty(x.name)) || request.Order.products.Any(x => x.price <= 0))
            return 0;

        var result = await repository.AddAsync(new()
        {
            CreateDate = request.Order.createDate,
            Status = Shared.Enums.StatusEnum.New,
            OrderLines = request.Order.products.Select(x => new OrderLine { Product = x.name, Price = x.price }).ToList(),
            ClientName = request.Order.clientName,
            AdditionalInfo = request.Order.additionalInfo
        });

        return result;
    }
}
