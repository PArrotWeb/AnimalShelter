using MediatR;

namespace AnimalShelter.Application.Requests.Orders.Commands.CreateOrder;

/// <summary>
/// Command for creating a new order
/// </summary>
public sealed record CreateOrderCommand : IRequest<Guid>
{

	/// <summary>
	/// Orderer name
	/// </summary>
	public string Name { get; init; } = null!;

	/// <summary>
	/// Orderer phone
	/// </summary>
	public string Phone { get; init; } = null!;

	/// <summary>
	/// Orderer email
	/// </summary>
	public string Email { get; init; } = null!;

	/// <summary>
	/// Planned date to pick up the animal
	/// </summary>
	public DateTime PlannedDate { get; init; }

	/// <summary>
	/// Comment for the order
	/// </summary>
	public string? Comment { get; init; }

	/// <summary>
	/// Id of the animal to order
	/// </summary>
	public Guid AnimalId { get; init; }
}