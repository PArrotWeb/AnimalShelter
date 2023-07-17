using AnimalShelter.Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Application.Requests.Events.Queries.GetEvents;

/// <summary>
/// Query handler for getting all events
/// </summary>
public sealed class GetEventsQueryHandler : IRequestHandler<GetEventsQuery, EventsVm>
{

	private readonly IAnimalShelterDbContext _dbContext;
	private readonly IMapper _mapper;

	public GetEventsQueryHandler(IAnimalShelterDbContext dbContext, IMapper mapper)
	{
		_dbContext = dbContext;
		_mapper = mapper;
	}

	#region IRequestHandler<GetEventsQuery,EventsVm> Members
	public async Task<EventsVm> Handle(GetEventsQuery request, CancellationToken cancellationToken)
	{
		// get all events from database and map them to EventDto
		var events = await _dbContext.Events
			.ProjectTo<EventDto>(_mapper.ConfigurationProvider)
			.ToListAsync(cancellationToken);

		// return view model with events
		return new EventsVm(events);
	}
	#endregion

}