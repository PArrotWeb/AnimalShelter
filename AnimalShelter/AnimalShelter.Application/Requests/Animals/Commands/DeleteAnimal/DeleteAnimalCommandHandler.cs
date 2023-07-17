using AnimalShelter.Application.Common.Exceptions;
using AnimalShelter.Application.Interfaces;
using AnimalShelter.Domain.Entities;
using MediatR;

namespace AnimalShelter.Application.Requests.Animals.Commands.DeleteAnimal;

/// <summary>
/// Command handler for deleting an animal
/// </summary>
public sealed class DeleteAnimalCommandHandler : IRequestHandler<DeleteAnimalCommand>
{

	private readonly IAnimalShelterDbContext _dbContext;

	public DeleteAnimalCommandHandler(IAnimalShelterDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	#region IRequestHandler<DeleteAnimalCommand> Members
	public async Task Handle(DeleteAnimalCommand request, CancellationToken cancellationToken)
	{
		// get entity to delete	from database
		var entity = await _dbContext.Animals.FindAsync(new object?[] {request.Id}, cancellationToken);

		// if entity is not found, throw exception
		if (entity == null)
		{
			throw new NotFoundException(nameof(Animal), request.Id);
		}

		// remove entity from database
		_dbContext.Animals.Remove(entity);
		await _dbContext.SaveChangesAsync(cancellationToken);
	}
	#endregion

}