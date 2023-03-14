using OrdersBackend.Shared.Enums;

namespace OrdersBackend.Shared.Functions.Orders.Queries;

public record OrderDetailsDto(int id, string clientName, DateTime createDate, decimal totalPrice, string additionalInfo, StatusEnum status, IEnumerable<OrderDetailsProductDto> products);
