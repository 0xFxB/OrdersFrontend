using MediatR;

namespace OrdersBackend.Shared.Functions.Orders.Commands;

public class AddOrderCommand : IRequest<int>
{
	public AddOrderCommand(AddOrderDto order)
	{
        Order = order;
    }

    public AddOrderDto Order { get; }
}
