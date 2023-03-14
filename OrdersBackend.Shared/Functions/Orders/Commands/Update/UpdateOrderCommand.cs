using MediatR;
using OrdersBackend.Shared.Functions.Orders.Commands;

namespace OrdersBackend.Shared.Functions.Orders;

public class UpdateOrderCommand : IRequest<int>
{
	public UpdateOrderCommand(UpdateOrderDto order)
	{
        Order = order;
    }

    public UpdateOrderDto Order { get; }
}
