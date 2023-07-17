using AnimalShelter.Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Application.Requests.Subscriptions.Queries.GetSubscriptions;

/// <summary>
/// Query handler for getting all subscriptions
/// </summary>
public class GetSubscriptionsQueryHandler : IRequestHandler<GetSubscriptionsQuery, SubscriptionsVm>
{

	private readonly IAnimalShelterDbContext _dbContext;
	private readonly IMapper _mapper;

	public GetSubscriptionsQueryHandler(IAnimalShelterDbContext dbContext, IMapper mapper)
	{
		_dbContext = dbContext;
		_mapper = mapper;
	}

	#region IRequestHandler<GetSubscriptionsQuery,SubscriptionsVm> Members
	public async Task<SubscriptionsVm> Handle(GetSubscriptionsQuery request, CancellationToken cancellationToken)
	{
		// get all subscriptions from database and map them to SubscriptionDto
		var query = await _dbContext.Subscriptions
			.ProjectTo<SubscriptionDto>(_mapper.ConfigurationProvider)
			.ToListAsync(cancellationToken);

		// return view model with subscriptions
		return new SubscriptionsVm(query);
	}
	#endregion

}