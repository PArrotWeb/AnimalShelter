using AnimalShelter.Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Application.Requests.Kinds.Queries.GetKinds;

/// <summary>
/// Query handler for getting all kinds
/// </summary>
public sealed class GetKindsQueryHandler : IRequestHandler<GetKindsQuery, KindsVm>
{

	private readonly IAnimalShelterDbContext _dbContext;
	private readonly IMapper _mapper;

	public GetKindsQueryHandler(IAnimalShelterDbContext dbContext, IMapper mapper)
	{
		_dbContext = dbContext;
		_mapper = mapper;
	}

	#region IRequestHandler<GetKindsQuery,KindsVm> Members
	public async Task<KindsVm> Handle(GetKindsQuery request, CancellationToken cancellationToken)
	{
		// get all kinds from database and map them to KindDto
		var kinds = await _dbContext.Kinds
			.ProjectTo<KindDto>(_mapper.ConfigurationProvider)
			.ToListAsync(cancellationToken);

		// return view model with all kinds
		return new KindsVm(kinds);
	}
	#endregion

}