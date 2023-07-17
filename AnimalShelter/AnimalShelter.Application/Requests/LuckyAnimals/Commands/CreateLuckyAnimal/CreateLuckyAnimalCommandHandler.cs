using AnimalShelter.Application.Interfaces;
using AnimalShelter.Domain.Entities;
using MediatR;

namespace AnimalShelter.Application.Requests.LuckyAnimals.Commands.CreateLuckyAnimal;

/// <summary>
/// Command handler for creating a new lucky animal
/// </summary>
public sealed class CreateLuckyAnimalCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
{

	private readonly IAnimalShelterDbContext _dbContext;

	public CreateLuckyAnimalCommandHandler(IAnimalShelterDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	#region IRequestHandler<CreateOrderCommand,Guid> Members
	public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
	{
		// create new lucky animal
		var entity = new LuckyAnimal
		{
			Id = new Guid(),
			PhotoUrl = request.PhotoUrl,
			Comment = request.Comment,
			AdoptionDate = request.AdoptionDate,
			AnimalId = request.AnimalId
		};

		// add entity to database
		await _dbContext.LuckyAnimals.AddAsync(entity, cancellationToken);
		await _dbContext.SaveChangesAsync(cancellationToken);

		// return id of new entity
		return entity.Id;
	}
	#endregion

}