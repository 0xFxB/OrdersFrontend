namespace OrdersBackend.Shared.Functions.Orders.Commands;

public record UpdateOrderRequest(int id, string clientName, string additionalInfo, IEnumerable<UpdateOrderProductLineRequest> products);
