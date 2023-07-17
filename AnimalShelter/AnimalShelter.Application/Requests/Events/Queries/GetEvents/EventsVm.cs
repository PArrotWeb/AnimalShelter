namespace AnimalShelter.Application.Requests.Events.Queries.GetEvents;

/// <summary>
/// View model for <see cref="GetEventsQuery" />
/// </summary>
/// <param name="Events"></param>
public sealed record EventsVm(IList<EventDto> Events);