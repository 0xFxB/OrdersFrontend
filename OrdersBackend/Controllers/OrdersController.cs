using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrdersBackend.Shared.Functions.Orders;
using OrdersBackend.Shared.Functions.Orders.Commands;
using OrdersBackend.Shared.Functions.Orders.Queries;

namespace OrdersBackend.Controllers;

[Route("api/orders"), ApiController]
public class OrdersController : ControllerBase
{
    private readonly IMediator mediator;

    public OrdersController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("all/{page}")]
    public async Task<IEnumerable<OrderViewModel>> GetOrders(int page=1)
    {
        var dto = await mediator.Send(new GetAllOrdersQuery(page));
        var viewModel = dto.Select(MapTo);
        return viewModel;
    }

    [HttpGet("{id}")]
    public async Task<OrderDetailsViewModel> GetDetails(int id)
    {
        var dto = await mediator.Send(new GetOrderDetailsQuery(id));
        var viewModel = MapTo(dto);
        return viewModel;
    }

    [HttpPost("add")]
    public async Task<int> AddOrder(AddOrderRequest request)
    {
        var result = await mediator.Send(new AddOrderCommand(MapTo(request)));
        return result;
    }

    [HttpPost("delete/{id}")]
    public async Task<int> DeleteOrder(int id)
    {
        var result = await mediator.Send(new DeleteOrderCommand(id));
        return result;
    }

    [HttpPost("change-status")]
    public async Task<int> ChangeOrderStatus(ChangeStatusRequest request)
    {
        var result = await mediator.Send(new ChangeStatusCommand(request.orderId, request.newStatus));
        return result;
    }

    [HttpPost("update")]
    public async Task<int> UpdateOrder(UpdateOrderRequest request)
    {
        var result = await mediator.Send(new UpdateOrderCommand(MapTo(request)));
        return result;
    }

    [HttpGet("count")]
    public async Task<int> GetTotalCount()
    {
        var result = await mediator.Send(new GetOrderCountQuery());
        return result;
    }

    private UpdateOrderDto MapTo(UpdateOrderRequest order)
        => new(order.id, order.clientName, order.additionalInfo, order.products.Select(MapTo));

    private UpdateOrderProductLineDto MapTo(UpdateOrderProductLineRequest product)
        => new(product.id ,product.name, product.price);

    private OrderDetailsViewModel MapTo(OrderDetailsDto order)
        => new(order.id, order.clientName, order.createDate, order.totalPrice, order.additionalInfo, order.status, order.products.Select(MapTo));

    private OrderDetailsProductViewModel MapTo(OrderDetailsProductDto product)
        => new(product.id ,product.name, product.price);

    private AddOrderDto MapTo(AddOrderRequest request)
        => new(request.clientName, request.createDate, request.additionalInfo, request.products.Select(MapTo));

    private AddOrderProductDto MapTo(AddOrderProductRequest product)
        => new(product.name, product.price);

    private OrderViewModel MapTo(OrderDto order)
        => new(order.id, order.createDate, order.status, order.clientName, order.orderPrice);
}
