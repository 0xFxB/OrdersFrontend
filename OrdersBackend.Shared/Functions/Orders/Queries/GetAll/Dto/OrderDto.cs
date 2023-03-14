using OrdersBackend.Shared.Enums;

namespace OrdersBackend.Shared.Functions.Orders.Queries;

public record OrderDto(int id, DateTime createDate, StatusEnum status, string clientName, decimal orderPrice);
