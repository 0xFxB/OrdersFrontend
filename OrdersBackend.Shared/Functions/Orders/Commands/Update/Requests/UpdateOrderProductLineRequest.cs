namespace OrdersBackend.Shared.Functions.Orders.Commands;

public record UpdateOrderProductLineRequest(int id, string name, decimal price);