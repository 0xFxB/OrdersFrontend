namespace OrdersBackend.Shared.Functions.Orders.Commands;

public record UpdateOrderDto(int id, string clientName, string additionalInfo, IEnumerable<UpdateOrderProductLineDto> products);
