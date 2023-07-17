using AnimalShelter.Application.Common.Exceptions;
using AnimalShelter.Application.Interfaces;
using AnimalShelter.Domain.Entities;
using MediatR;

namespace AnimalShelter.Application.Requests.Orders.Commands.DeleteOrder;

/// <summary>
/// Command handler for deleting an order
/// </summary>
public sealed class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
{

	private readonly IAnimalShelterDbContext _dbContext;

	public DeleteOrderCommandHandler(IAnimalShelterDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	#region IRequestHandler<DeleteOrderCommand> Members
	public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
	{
		// find entity to delete by id in database
		var entity = await _dbContext.Orders.FindAsync(new object?[] {request.Id}, cancellationToken);

		// check if entity not found
		if (entity == null)
		{
			throw new NotFoundException(nameof(Order), request.Id);
		}

		// delete entity from database
		_dbContext.Orders.Remove(entity);
		await _dbContext.SaveChangesAsync(cancellationToken);
	}
	#endregion

}