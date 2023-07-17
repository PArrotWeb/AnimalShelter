using MediatR;

namespace AnimalShelter.Application.Requests.LuckyAnimals.Commands.CreateLuckyAnimal;

/// <summary>
/// Command for creating a new lucky animal
/// </summary>
public sealed record CreateOrderCommand : IRequest<Guid>
{

	/// <summary>
	/// Url of Photo of the animal
	/// </summary>
	public string PhotoUrl { get; init; } = string.Empty;

	/// <summary>
	/// Comment
	/// </summary>
	public string? Comment { get; init; }

	/// <summary>
	/// Date of adoption
	/// </summary>
	public DateTime AdoptionDate { get; init; }

	/// <summary>
	/// Id of the animal
	/// </summary>
	public Guid AnimalId { get; init; }
}