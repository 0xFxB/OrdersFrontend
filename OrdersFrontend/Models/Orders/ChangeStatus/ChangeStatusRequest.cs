using OrdersFrontend.Enums;

namespace OrdersFrontend.Models.Orders;

public record ChangeStatusRequest(int orderId, StatusEnum newStatus);
