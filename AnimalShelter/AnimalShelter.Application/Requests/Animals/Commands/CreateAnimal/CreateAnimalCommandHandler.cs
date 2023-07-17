using AnimalShelter.Application.Interfaces;
using AnimalShelter.Domain.Entities;
using MediatR;

namespace AnimalShelter.Application.Requests.Animals.Commands.CreateAnimal;

/// <summary>
/// Command handler for creating a new animal
/// </summary>
public sealed class CreateAnimalCommandHandler : IRequestHandler<CreateAnimalCommand, Guid>
{

	private readonly IAnimalShelterDbContext _dbContext;

	public CreateAnimalCommandHandler(IAnimalShelterDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	#region IRequestHandler<CreateAnimalCommand,Guid> Members
	public async Task<Guid> Handle(CreateAnimalCommand request, CancellationToken cancellationToken)
	{
		// create new animal
		var animal = new Animal
		{
			Id = new Guid(),
			PhotoUrl = request.PhotoUrl,
			Name = request.Name,
			Description = request.Description,
			DescriptionExtra = request.DescriptionExtra,
			History = request.History,
			AdmissionDate = request.AdmissionDate,
			Height = request.Height,
			Weight = request.Weight,
			KindId = request.KindId,
			AnimalAvailabilityId = request.AnimalAvailabilityId
		};

		// add animal to database
		await _dbContext.Animals.AddAsync(animal, cancellationToken);
		await _dbContext.SaveChangesAsync(cancellationToken);

		// return id of animal
		return animal.Id;
	}
	#endregion

}