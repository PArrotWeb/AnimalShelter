using MediatR;

namespace AnimalShelter.Application.Requests.Animals.Commands.UpdateAnimal.UpdateAnimalPhoto;

/// <summary>
/// Command for updating the photo of a lucky animal
/// </summary>
public sealed record UpdateAnimalPhotoCommand : IRequest
{
	/// <summary>
	/// Id of the lucky animal to update
	/// </summary>
	public Guid Id { get; init; }

	/// <summary>
	/// Url of the photo to update
	/// </summary>
	public string PhotoUrl { get; init; } = null!;
}