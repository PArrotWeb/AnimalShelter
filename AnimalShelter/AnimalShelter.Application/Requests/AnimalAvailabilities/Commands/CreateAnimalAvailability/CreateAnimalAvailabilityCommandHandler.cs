using AnimalShelter.Application.Interfaces;
using AnimalShelter.Domain.Entities;
using MediatR;

namespace AnimalShelter.Application.Requests.AnimalAvailabilities.Commands.CreateAnimalAvailability;

/// <summary>
/// Command handler for creating a new animal availability
/// </summary>
public sealed class CreateAnimalAvailabilityCommandHandler : IRequestHandler<CreateAnimalAvailabilityCommand, Guid>
{

	private readonly IAnimalShelterDbContext _dbContext;

	public CreateAnimalAvailabilityCommandHandler(IAnimalShelterDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	#region IRequestHandler<CreateAnimalAvailabilityCommand,Guid> Members
	public async Task<Guid> Handle(CreateAnimalAvailabilityCommand request, CancellationToken cancellationToken)
	{
		// create new animal availability
		var animalAvailability = new AnimalAvailability
		{
			Id = new Guid(),
			Name = request.Name
		};

		// add to database
		await _dbContext.AnimalAvailabilities.AddAsync(animalAvailability, cancellationToken);
		await _dbContext.SaveChangesAsync(cancellationToken);

		// return id of new animal availability
		return animalAvailability.Id;
	}
	#endregion

}