namespace OrdersFrontend.Models.Orders;

public record UpdateOrder(int id, string clientName, string additionalInfo, IEnumerable<UpdateOrderProduct> products);
