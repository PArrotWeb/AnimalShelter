using MediatR;

namespace AnimalShelter.Application.Requests.Animals.Commands.DeleteAnimal;

/// <summary>
/// Command for deleting an animal
/// </summary>
public sealed record DeleteAnimalCommand : IRequest
{
	/// <summary>
	/// Id of the animal to delete
	/// </summary>
	public Guid Id { get; init; }
}