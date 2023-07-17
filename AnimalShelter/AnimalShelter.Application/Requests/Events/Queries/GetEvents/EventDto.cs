using AnimalShelter.Application.Common.Mappings;
using AnimalShelter.Domain.Entities;
using AutoMapper;

namespace AnimalShelter.Application.Requests.Events.Queries.GetEvents;

/// <summary>
/// Represents data transfer object for <see cref="Event" /> model
/// </summary>
public sealed class EventDto : IMapWith<Event>
{
	/// <summary>
	/// Id of the event
	/// </summary>
	public Guid Id { get; init; }

	/// <summary>
	/// Url of the photo of the event
	/// </summary>
	public string PhotoUrl { get; init; } = null!;

	/// <summary>
	/// Description of the event
	/// </summary>
	public string Description { get; init; } = null!;

	/// <summary>
	/// Link to the event
	/// </summary>
	public string? Link { get; init; }

	#region IMapWith<Event> Members
	public void Mapping(Profile profile)
	{
		profile.CreateMap<Event, EventDto>();
	}
	#endregion

}