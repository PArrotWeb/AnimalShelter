using MediatR;

namespace AnimalShelter.Application.Requests.AnimalAvailabilities.Commands.CreateAnimalAvailability;

/// <summary>
/// Command for creating a new animal availability
/// </summary>
public sealed record CreateAnimalAvailabilityCommand : IRequest<Guid>
{
	/// <summary>
	/// Name of the animal availability
	/// </summary>
	public string Name { get; init; } = null!;
}