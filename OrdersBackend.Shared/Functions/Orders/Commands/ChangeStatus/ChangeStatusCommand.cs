using MediatR;
using OrdersBackend.Shared.Enums;

namespace OrdersBackend.Shared.Functions.Orders.Commands;

public class ChangeStatusCommand : IRequest<int>
{
	public ChangeStatusCommand(int id, StatusEnum newStatus)
	{
        Id = id;
        NewStatus = newStatus;
    }

    public int Id { get; }
    public StatusEnum NewStatus { get; }
}
