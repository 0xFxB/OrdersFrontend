using OrdersFrontend.Enums;

namespace OrdersFrontend.Models.Orders;

public record OrderDetails(int id, string clientName, DateTime createDate, decimal totalPrice, string additionalInfo, StatusEnum status, IEnumerable<OrderDetailsProduct> products);