using MediatR;

namespace OrdersBackend.Shared.Functions.Orders.Queries;

public class GetOrderDetailsQuery : IRequest<OrderDetailsDto>
{
	public GetOrderDetailsQuery(int id)
	{
        Id = id;
    }

    public int Id { get; }
}
