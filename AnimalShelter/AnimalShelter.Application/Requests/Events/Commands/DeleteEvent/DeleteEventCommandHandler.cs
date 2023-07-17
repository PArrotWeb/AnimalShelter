using AnimalShelter.Application.Common.Exceptions;
using AnimalShelter.Application.Interfaces;
using AnimalShelter.Domain.Entities;
using MediatR;

namespace AnimalShelter.Application.Requests.Events.Commands.DeleteEvent;

/// <summary>
/// Command handler for deleting an event
/// </summary>
public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
{

	private readonly IAnimalShelterDbContext _dbContext;

	public DeleteEventCommandHandler(IAnimalShelterDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	#region IRequestHandler<DeleteEventCommand> Members
	public async Task Handle(DeleteEventCommand request, CancellationToken cancellationToken)
	{
		// find event to delete in database
		var entity = await _dbContext.Events.FindAsync(new object?[] {request.Id}, cancellationToken);

		// if event does not exist, throw exception
		if (entity == null)
		{
			throw new NotFoundException(nameof(Event), request.Id);
		}

		// remove event from database
		_dbContext.Events.Remove(entity);
		await _dbContext.SaveChangesAsync(cancellationToken);
	}
	#endregion

}