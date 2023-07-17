using AnimalShelter.Application.Interfaces;
using AnimalShelter.Domain.Entities;
using MediatR;

namespace AnimalShelter.Application.Requests.Orders.Commands.CreateOrder;

/// <summary>
/// Command handler for creating a new order
/// </summary>
public sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
{

	private readonly IAnimalShelterDbContext _dbContext;

	public CreateOrderCommandHandler(IAnimalShelterDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	#region IRequestHandler<CreateOrderCommand,Guid> Members
	public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
	{
		// create new order
		var entity = new Order
		{
			Id = new Guid(),
			Name = request.Name,
			Phone = request.Phone,
			Email = request.Email,
			PlannedDate = request.PlannedDate,
			Comment = request.Comment,
			AnimalId = request.AnimalId
		};

		// save order entity to database
		await _dbContext.Orders.AddAsync(entity, cancellationToken);
		await _dbContext.SaveChangesAsync(cancellationToken);

		// return id of the new order entity
		return entity.Id;
	}
	#endregion

}