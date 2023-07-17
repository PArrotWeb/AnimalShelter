using MediatR;

namespace AnimalShelter.Application.Requests.Events.Commands.UpdateEvent.UpdateEventPhoto;

/// <summary>
/// Command for updating event photo
/// </summary>
public sealed record UpdateEventPhotoCommand : IRequest
{
	/// <summary>
	/// Id of the event to update
	/// </summary>
	public Guid Id { get; init; }

	/// <summary>
	/// Url of the photo to update
	/// </summary>
	public string PhotoUrl { get; init; } = null!;
}