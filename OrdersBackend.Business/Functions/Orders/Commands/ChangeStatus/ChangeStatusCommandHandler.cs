using MediatR;
using OrdersBackend.Shared.Entities;
using OrdersBackend.Shared.Functions.Orders.Commands;
using OrdersBackend.Shared.Interfaces.Repositories;

namespace OrdersBackend.Business.Functions.Orders.Commands;

public class ChangeStatusCommandHandler : IRequestHandler<ChangeStatusCommand, int>
{
    private readonly IRepository<Order> repository;

    public ChangeStatusCommandHandler(IRepository<Order> repository)
    {
        this.repository = repository;
    }

    public async Task<int> Handle(ChangeStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id);
        if (entity is null || entity.Status == request.NewStatus || entity.Status != Shared.Enums.StatusEnum.New)
            return 0;

        entity.Status = request.NewStatus;
        var result = await repository.UpdateAsync(entity);
        return result;
    }
}
