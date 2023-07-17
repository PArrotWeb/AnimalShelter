using MediatR;

namespace AnimalShelter.Application.Requests.AnimalAvailabilities.Commands.DeleteAnimalAvailability;

/// <summary>
/// Command for deleting an animal availability
/// </summary>
public sealed record DeleteAnimalAvailabilityCommand : IRequest
{
	/// <summary>
	/// Id of the animal availability to delete
	/// </summary>
	public Guid Id { get; init; }
}