using OrdersFrontend.Enums;

namespace OrdersFrontend.Models.Orders;

public record Order(int id, DateTime createDate, StatusEnum status, string clientName, decimal orderPrice, string additionalInfo, IEnumerable<OrderLine> elements);
