namespace OrdersFrontend.Models.Orders;

public record AddOrderRequest(string clientName, DateTime createDate, string additionalInfo, IEnumerable<AddOrderProductRequest> products);
