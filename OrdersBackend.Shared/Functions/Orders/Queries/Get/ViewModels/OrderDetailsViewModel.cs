using OrdersBackend.Shared.Enums;

namespace OrdersBackend.Shared.Functions.Orders.Queries;

public record OrderDetailsViewModel(int id, string clientName, DateTime createDate, decimal totalPrice, string additionalInfo, StatusEnum status, IEnumerable<OrderDetailsProductViewModel> products);

