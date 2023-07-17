using MediatR;

namespace AnimalShelter.Application.Requests.Orders.Commands.DeleteOrder;

/// <summary>
/// Command for deleting an order
/// </summary>
public sealed record DeleteOrderCommand : IRequest
{
	/// <summary>
	/// Id of the order to delete
	/// </summary>
	public Guid Id { get; init; }
}