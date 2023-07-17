using MediatR;

namespace AnimalShelter.Application.Requests.Animals.Commands.CreateAnimal;

/// <summary>
/// Command to create a new animal
/// </summary>
public sealed record CreateAnimalCommand : IRequest<Guid>
{
	/// <summary>
	/// Photo url on server of the animal
	/// </summary>
	public string PhotoUrl { get; init; } = string.Empty;

	/// <summary>
	/// Name of the animal
	/// </summary>
	public string Name { get; init; } = null!;

	/// <summary>
	/// Description of the animal
	/// </summary>
	public string? Description { get; init; }

	/// <summary>
	/// Extra description of the animal
	/// </summary>
	public string? DescriptionExtra { get; init; }

	/// <summary>
	/// Admission history of the animal
	/// </summary>
	public string? History { get; init; }

	/// <summary>
	/// Date of admission of the animal
	/// </summary>
	public DateTime AdmissionDate { get; init; }

	/// <summary>
	/// Height of the animal
	/// </summary>
	public float Height { get; init; }

	/// <summary>
	/// Weight of the animal
	/// </summary>
	public float Weight { get; init; }

	/// <summary>
	/// Id of the Kind of the animal
	/// </summary>
	public Guid KindId { get; init; }

	/// <summary>
	/// Id of the AnimalAvailability of the animal
	/// </summary>
	public Guid AnimalAvailabilityId { get; init; }
}