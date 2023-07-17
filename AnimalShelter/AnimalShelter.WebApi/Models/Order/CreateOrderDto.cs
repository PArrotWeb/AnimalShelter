using AnimalShelter.Application.Common.Mappings;
using AnimalShelter.Application.Requests.Orders.Commands.CreateOrder;
using AutoMapper;

namespace AnimalShelter.WebApi.Models.Order;

public class CreateOrderDto : IMapWith<CreateOrderCommand>
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
	public string? Comment { get; init; } = null!;

	/// <summary>
	/// Id of the animal to order
	/// </summary>
	public Guid AnimalId { get; init; }

	#region IMapWith<CreateOrderCommand> Members
	public void Mapping(Profile profile)
	{
		profile.CreateMap<CreateOrderDto, CreateOrderCommand>();
	}
	#endregion

}