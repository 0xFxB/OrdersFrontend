using MediatR;

namespace OrdersBackend.Shared.Functions.Orders.Queries;

public class GetAllOrdersQuery : IRequest<IEnumerable<OrderDto>>
{
	public GetAllOrdersQuery(int page)
	{
        Page = page;
    }

    public int Page { get; }
}
