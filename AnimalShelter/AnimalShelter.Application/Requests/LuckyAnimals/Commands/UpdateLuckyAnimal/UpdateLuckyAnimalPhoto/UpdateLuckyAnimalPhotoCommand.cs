using MediatR;

namespace AnimalShelter.Application.Requests.LuckyAnimals.Commands.UpdateLuckyAnimal.UpdateLuckyAnimalPhoto;

/// <summary>
/// Command for updating a lucky animal photo
/// </summary>
public sealed record UpdateLuckyAnimalPhotoCommand : IRequest
{
	/// <summary>
	/// Id of the updating lucky animal
	/// </summary>
	public Guid Id { get; init; }

	/// <summary>
	/// Url of Photo of the animal
	/// </summary>
	public string PhotoUrl { get; init; } = null!;
}