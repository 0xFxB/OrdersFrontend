using Newtonsoft.Json;
using OrdersFrontend.Models.Orders;
using System.Net.Http.Json;

namespace OrdersFrontend.Api;

public class OrdersHttpClient
{
    private readonly IHttpClientFactory httpClientFactory;

    public OrdersHttpClient(IHttpClientFactory httpClientFactory)
	{
        this.httpClientFactory = httpClientFactory;
    }

    internal async Task<IEnumerable<Order>> GetAllOrders(int page = 1)
    {
        var response = await httpClientFactory.CreateClient(Settings.NAME).GetAsync($"api/orders/all/{page}");
        var responseModel = JsonConvert.DeserializeObject<IEnumerable<Order>>(await response.Content.ReadAsStringAsync());
        return responseModel ?? Enumerable.Empty<Order>();
    }

    internal async Task<int> AddOrder(AddOrderRequest request)
    {
        var response = await httpClientFactory.CreateClient(Settings.NAME).PostAsJsonAsync("api/orders/add", request);
        var responseModel = JsonConvert.DeserializeObject<int>(await response.Content.ReadAsStringAsync());
        return responseModel;
    }

    internal async Task<OrderDetails> GetDetails(int id)
    {
        var response = await httpClientFactory.CreateClient(Settings.NAME).GetAsync($"api/orders/{id}");
        var responseModel = JsonConvert.DeserializeObject<OrderDetails>(await response.Content.ReadAsStringAsync());
        return responseModel;
    }

    internal async Task<int> DeleteOrder(int id)
    {
        var response = await httpClientFactory.CreateClient(Settings.NAME).PostAsync($"api/orders/delete/{id}", null);
        var responseModel = JsonConvert.DeserializeObject<int>(await response.Content.ReadAsStringAsync());
        return responseModel;
    }

    internal async Task<int> ChangeStatus(ChangeStatusRequest request)
    {
        var response = await httpClientFactory.CreateClient(Settings.NAME).PostAsJsonAsync($"api/orders/change-status", request);
        var responseModel = JsonConvert.DeserializeObject<int>(await response.Content.ReadAsStringAsync());
        return responseModel;
    }

    internal async Task<int> UpdateOrder(UpdateOrder request)
    {
        var response = await httpClientFactory.CreateClient(Settings.NAME).PostAsJsonAsync($"api/orders/update", request);
        var responseModel = JsonConvert.DeserializeObject<int>(await response.Content.ReadAsStringAsync());
        return responseModel;
    }

    internal async Task<int> GetCount()
    {
        var response = await httpClientFactory.CreateClient(Settings.NAME).GetAsync($"api/orders/count");
        var responseModel = JsonConvert.DeserializeObject<int>(await response.Content.ReadAsStringAsync());
        return responseModel;
    }
}
