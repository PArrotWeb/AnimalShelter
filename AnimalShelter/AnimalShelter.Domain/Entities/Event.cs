namespace AnimalShelter.Domain.Entities;

/// <summary>
/// Event entity
/// </summary>
public class Event
{
	/// <summary>
	/// Id of event
	/// </summary>
	public Guid Id { get; set; }

	/// <summary>
	/// Url of photo of event
	/// </summary>
	public string PhotoUrl { get; set; } = null!;

	/// <summary>
	/// Description of event
	/// </summary>
	public string Description { get; set; } = null!;

	/// <summary>
	/// Link to event
	/// </summary>
	public string? Link { get; set; }
}