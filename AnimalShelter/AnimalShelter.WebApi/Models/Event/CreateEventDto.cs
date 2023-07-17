using AnimalShelter.Application.Common.Mappings;
using AnimalShelter.Application.Requests.Events.Commands.CreateEvent;
using AutoMapper;

namespace AnimalShelter.WebApi.Models.Event;

/// <summary>
/// DTO for creating event
/// </summary>
public class CreateEventDto : IMapWith<CreateEventCommand>
{
	/// <summary>
	/// Base64 encoded photo of event
	/// </summary>
	public string PhotoBase64 { get; init; } = null!;

	/// <summary>
	/// Description of the event
	/// </summary>
	public string Description { get; init; } = null!;

	/// <summary>
	/// Link to the event
	/// </summary>
	public string? Link { get; init; }

	#region IMapWith<CreateEventCommand> Members
	public void Mapping(Profile profile)
	{
		profile.CreateMap<CreateEventDto, CreateEventCommand>()
			.ForMember(d => d.PhotoUrl, o => o.Ignore());
	}
	#endregion

}