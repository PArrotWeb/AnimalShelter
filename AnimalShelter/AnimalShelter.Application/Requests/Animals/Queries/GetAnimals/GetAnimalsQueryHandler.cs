using AnimalShelter.Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Application.Requests.Animals.Queries.GetAnimals;

/// <summary>
/// Query handler for getting all animals
/// </summary>
public sealed class GetAnimalsQueryHandler : IRequestHandler<GetAnimalsQuery, AnimalsVm>
{

	private readonly IAnimalShelterDbContext _dbContext;
	private readonly IMapper _mapper;

	public GetAnimalsQueryHandler(IAnimalShelterDbContext dbContext, IMapper mapper)
	{
		_dbContext = dbContext;
		_mapper = mapper;
	}

	#region IRequestHandler<GetAnimalsQuery,AnimalsVm> Members
	public async Task<AnimalsVm> Handle(GetAnimalsQuery request, CancellationToken cancellationToken)
	{
		// get all animals from the database and map them to AnimalDto
		var animals = await _dbContext.Animals
			.ProjectTo<AnimalDto>(_mapper.ConfigurationProvider)
			.ToListAsync(cancellationToken);

		// return the viewmodel of all animals
		return new AnimalsVm(animals);
	}
	#endregion

}