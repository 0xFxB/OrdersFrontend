namespace OrdersBackend.Shared.Functions.Orders.Commands;

public record AddOrderRequest(string clientName, DateTime createDate, string additionalInfo, IEnumerable<AddOrderProductRequest> products);