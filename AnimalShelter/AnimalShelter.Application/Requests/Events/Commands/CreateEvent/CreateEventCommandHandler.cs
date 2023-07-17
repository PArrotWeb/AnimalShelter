using AnimalShelter.Application.Interfaces;
using AnimalShelter.Domain.Entities;
using MediatR;

namespace AnimalShelter.Application.Requests.Events.Commands.CreateEvent;

/// <summary>
/// Command handler for creating a new event
/// </summary>
public sealed class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
{

	private readonly IAnimalShelterDbContext _dbContext;

	public CreateEventCommandHandler(IAnimalShelterDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	#region IRequestHandler<CreateEventCommand,Guid> Members
	public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
	{
		// create new event
		var entity = new Event
		{
			Id = new Guid(),
			PhotoUrl = request.PhotoUrl,
			Description = request.Description,
			Link = request.Link
		};

		// add event to database
		await _dbContext.Events.AddAsync(entity, cancellationToken);
		await _dbContext.SaveChangesAsync(cancellationToken);

		// return id of new event
		return entity.Id;
	}
	#endregion

}