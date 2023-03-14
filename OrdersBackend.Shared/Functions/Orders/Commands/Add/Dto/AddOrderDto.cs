namespace OrdersBackend.Shared.Functions.Orders.Commands;

public record AddOrderDto(string clientName, DateTime createDate, string additionalInfo, IEnumerable<AddOrderProductDto> products);