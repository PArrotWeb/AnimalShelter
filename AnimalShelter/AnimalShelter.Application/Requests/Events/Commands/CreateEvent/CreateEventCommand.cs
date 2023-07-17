using MediatR;

namespace AnimalShelter.Application.Requests.Events.Commands.CreateEvent;

/// <summary>
/// Command for creating a new event
/// </summary>
public sealed record CreateEventCommand : IRequest<Guid>
{
	/// <summary>
	/// Photo url on server of the event
	/// </summary>
	public string PhotoUrl { get; init; } = string.Empty;

	/// <summary>
	/// Description of the event
	/// </summary>
	public string Description { get; init; } = null!;

	/// <summary>
	/// Link to the event
	/// </summary>
	public string? Link { get; init; }
}