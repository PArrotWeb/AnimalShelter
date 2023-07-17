using AnimalShelter.Application.Common.Mappings;
using AnimalShelter.Domain.Entities;
using AutoMapper;

namespace AnimalShelter.Application.Requests.Orders.Queries.GetOrders;

/// <summary>
/// Represents data transfer object for <see cref="Order" />
/// </summary>
public sealed class OrderDto : IMapWith<Order>
{
	/// <summary>
	/// Id of the order
	/// </summary>
	public Guid Id { get; init; }

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
	/// Comment
	/// </summary>
	public string? Comment { get; init; }

	/// <summary>
	/// Id of the animal to order
	/// </summary>
	public Guid AnimalId { get; init; }

	#region IMapWith<Order> Members
	public void Mapping(Profile profile)
	{
		profile.CreateMap<Order, OrderDto>();
	}
	#endregion

}