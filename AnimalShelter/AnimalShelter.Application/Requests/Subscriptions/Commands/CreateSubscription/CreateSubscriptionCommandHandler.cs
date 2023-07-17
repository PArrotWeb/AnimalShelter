using AnimalShelter.Application.Interfaces;
using AnimalShelter.Domain.Entities;
using MediatR;

namespace AnimalShelter.Application.Requests.Subscriptions.Commands.CreateSubscription;

/// <summary>
/// Command handler for creating a new subscription
/// </summary>
public sealed class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, Guid>
{

	private readonly IAnimalShelterDbContext _dbContext;

	public CreateSubscriptionCommandHandler(IAnimalShelterDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	#region IRequestHandler<CreateSubscriptionCommand,Guid> Members
	public async Task<Guid> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
	{
		// create new subscription
		var entity = new Subscription
		{
			Id = new Guid(),
			Email = request.Email
		};

		// add subscription to database
		await _dbContext.Subscriptions.AddAsync(entity, cancellationToken);
		await _dbContext.SaveChangesAsync(cancellationToken);

		// return id of new subscription
		return entity.Id;
	}
	#endregion

}