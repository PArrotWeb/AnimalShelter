using MediatR;

namespace AnimalShelter.Application.Requests.Events.Commands.DeleteEvent;

/// <summary>
/// Command for deleting an event
/// </summary>
public sealed record DeleteEventCommand : IRequest
{
	/// <summary>
	/// Id of the event to delete
	/// </summary>
	public Guid Id { get; init; }
}