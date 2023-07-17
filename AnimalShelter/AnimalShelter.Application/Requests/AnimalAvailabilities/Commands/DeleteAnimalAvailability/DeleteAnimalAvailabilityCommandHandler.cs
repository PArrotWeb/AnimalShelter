using AnimalShelter.Application.Common.Exceptions;
using AnimalShelter.Application.Interfaces;
using AnimalShelter.Domain.Entities;
using MediatR;

namespace AnimalShelter.Application.Requests.AnimalAvailabilities.Commands.DeleteAnimalAvailability;

/// <summary>
/// Command handler for deleting an animal availability
/// </summary>
public sealed class DeleteAnimalAvailabilityCommandHandler : IRequestHandler<DeleteAnimalAvailabilityCommand>
{

	private readonly IAnimalShelterDbContext _dbContext;

	public DeleteAnimalAvailabilityCommandHandler(IAnimalShelterDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	#region IRequestHandler<DeleteAnimalAvailabilityCommand> Members
	public async Task Handle(DeleteAnimalAvailabilityCommand request, CancellationToken cancellationToken)
	{
		// get entity from database
		var entity = await _dbContext.AnimalAvailabilities.FindAsync(new object?[] {request.Id}, cancellationToken);

		// check if entity exists
		if (entity == null)
		{
			throw new NotFoundException(nameof(AnimalAvailability), request.Id);
		}

		// remove from database
		_dbContext.AnimalAvailabilities.Remove(entity);
		await _dbContext.SaveChangesAsync(cancellationToken);
	}
	#endregion

}