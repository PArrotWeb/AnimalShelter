using MediatR;

namespace AnimalShelter.Application.Requests.Events.Queries.GetEvents;

/// <summary>
/// Query for getting all events
/// </summary>
public sealed record GetEventsQuery : IRequest<EventsVm>;