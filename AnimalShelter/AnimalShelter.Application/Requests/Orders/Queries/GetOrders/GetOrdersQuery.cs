using MediatR;

namespace AnimalShelter.Application.Requests.Orders.Queries.GetOrders;

/// <summary>
/// Query for getting all orders
/// </summary>
public sealed record GetOrdersQuery : IRequest<OrdersVm>;