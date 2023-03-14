using MediatR;

namespace OrdersBackend.Shared.Functions.Orders.Commands;

public class DeleteOrderCommand : IRequest<int>
{
	public DeleteOrderCommand(int id)
	{
        Id = id;
    }

    public int Id { get; }
}
