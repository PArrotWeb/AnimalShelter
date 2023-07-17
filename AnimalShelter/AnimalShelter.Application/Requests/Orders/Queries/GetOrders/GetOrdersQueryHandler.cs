using AnimalShelter.Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Application.Requests.Orders.Queries.GetOrders;

/// <summary>
/// Query handler for getting all orders
/// </summary>
public sealed class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, OrdersVm>
{

	private readonly IAnimalShelterDbContext _dbContext;
	private readonly IMapper _mapper;

	public GetOrdersQueryHandler(IAnimalShelterDbContext dbContext, IMapper mapper)
	{
		_dbContext = dbContext;
		_mapper = mapper;
	}

	#region IRequestHandler<GetOrdersQuery,OrdersVm> Members
	public async Task<OrdersVm> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
	{
		// get all orders from database and map them to OrderDto
		var orders = await _dbContext.Orders
			.ProjectTo<OrderDto>(_mapper.ConfigurationProvider)
			.ToListAsync(cancellationToken);

		// return view model with orders
		return new OrdersVm(orders);
	}
	#endregion

}