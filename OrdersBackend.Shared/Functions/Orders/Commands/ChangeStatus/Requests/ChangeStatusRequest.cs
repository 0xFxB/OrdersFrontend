using OrdersBackend.Shared.Enums;

namespace OrdersBackend.Shared.Functions.Orders.Commands;

public record ChangeStatusRequest(int orderId, StatusEnum newStatus);