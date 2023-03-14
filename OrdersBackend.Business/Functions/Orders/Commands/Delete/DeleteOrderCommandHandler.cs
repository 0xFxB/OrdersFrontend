using MediatR;
using OrdersBackend.Shared.Entities;
using OrdersBackend.Shared.Functions.Orders.Commands;
using OrdersBackend.Shared.Interfaces.Repositories;

namespace OrdersBackend.Business.Functions.Orders.Commands;

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, int>
{
    private readonly IRepository<Order> repository;

    public DeleteOrderCommandHandler(IRepository<Order> repository)
    {
        this.repository = repository;
    }

    public async Task<int> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id);
        if(entity is null || entity.Status != Shared.Enums.StatusEnum.New)
            return 0;

        var results = await repository.DeleteAsync(entity);
        return results;
    }
}
