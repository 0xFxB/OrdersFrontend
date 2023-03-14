using MediatR;
using Microsoft.EntityFrameworkCore;
using OrdersBackend.Shared.Entities;
using OrdersBackend.Shared.Functions.Orders;
using OrdersBackend.Shared.Interfaces.Repositories;

namespace OrdersBackend.Business.Functions.Orders;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, int>
{
    private readonly IRepository<Order> orderRepository;
    private readonly IRepository<OrderLine> lineRepository;

    public UpdateOrderCommandHandler(IRepository<Order> orderRepository, IRepository<OrderLine> lineRepository)
    {
        this.orderRepository = orderRepository;
        this.lineRepository = lineRepository;
    }

    public async Task<int> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var entity = await orderRepository.GetByIdAsync(request.Order.id, x => x.Include(y => y.OrderLines));
        if (entity is null || entity.Status != Shared.Enums.StatusEnum.New)
            return 0;

        ICollection<OrderLine> orderLines = request.Order.products.Select(x => new OrderLine { Price = x.price, Product = x.name })
            .ToList();

        entity.AdditionalInfo = request.Order.additionalInfo;
        entity.ClientName = request.Order.clientName;

        var result = await orderRepository.UpdateAsync(entity);
        result = await UpdateOrderLines(entity.Id, orderLines);
        return result;
    }

    private async Task<int> UpdateOrderLines(int orderId, ICollection<OrderLine> newLines)
    {
        int changeCount = 0;
        var entities = (await lineRepository.GetAllAsync(new() { Func = x => x.Where(y => y.OrderId == orderId) })).ToList();
        foreach(var line in newLines)
        {
            if (line.Id == 0)
            {
                changeCount += await lineRepository.AddAsync(new() { OrderId = orderId, Price = line.Price, Product = line.Product });
                continue;
            }

            if (entities.Any(x => x.Id == line.Id))
            {
                var entity = entities.First(x => x.Id == line.Id);
                entity.Price = line.Price;
                entity.Product = line.Product;
                changeCount += await lineRepository.UpdateAsync(entity);
                entities.Remove(entity);
            }
        }
        foreach (var entity in entities)
            changeCount += await lineRepository.DeleteAsync(entity);

        return changeCount;
    }
}
