using AnimalShelter.Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Application.Requests.AnimalAvailabilities.Queries.GetAnimalAvailabilities;

/// <summary>
/// Query handler to get all animal availabilities
/// </summary>
public sealed class
	GetAnimalAvailabilitiesQueryHandler : IRequestHandler<GetAnimalAvailabilitiesQuery, AnimalAvailabilitiesVm>
{

	private readonly IAnimalShelterDbContext _dbContext;
	private readonly IMapper _mapper;

	public GetAnimalAvailabilitiesQueryHandler(IAnimalShelterDbContext dbContext, IMapper mapper)
	{
		_dbContext = dbContext;
		_mapper = mapper;
	}

	#region IRequestHandler<GetAnimalAvailabilitiesQuery,AnimalAvailabilitiesVm> Members
	public async Task<AnimalAvailabilitiesVm> Handle(GetAnimalAvailabilitiesQuery request,
		CancellationToken cancellationToken)
	{
		// get all animal availabilities from database and map them to AnimalAvailabilityDto
		var animalAvailabilities = await _dbContext.AnimalAvailabilities
			.ProjectTo<AnimalAvailabilityDto>(_mapper.ConfigurationProvider)
			.ToListAsync(cancellationToken);

		// return them as AnimalAvailabilitiesVm
		return new AnimalAvailabilitiesVm(animalAvailabilities);
	}
	#endregion

}