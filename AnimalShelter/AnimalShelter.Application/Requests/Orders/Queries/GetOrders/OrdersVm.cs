namespace AnimalShelter.Application.Requests.Orders.Queries.GetOrders;

/// <summary>
/// View model for <see cref="GetOrdersQuery" />
/// </summary>
/// <param name="Orders"></param>
public sealed record OrdersVm(IList<OrderDto> Orders);