using AnimalShelter.Application.Interfaces;
using AnimalShelter.Domain.Entities;
using MediatR;

namespace AnimalShelter.Application.Requests.Kinds.Commands.CreateKind;

/// <summary>
/// Command handler for creating a new kind
/// </summary>
public sealed class CreateKindCommandHandler : IRequestHandler<CreateKindCommand, Guid>
{

	private readonly IAnimalShelterDbContext _dbContext;

	public CreateKindCommandHandler(IAnimalShelterDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	#region IRequestHandler<CreateKindCommand,Guid> Members
	public async Task<Guid> Handle(CreateKindCommand request, CancellationToken cancellationToken)
	{
		// create new kind
		var entity = new Kind
		{
			Id = new Guid(),
			Name = request.Name
		};

		// add entity to database
		await _dbContext.Kinds.AddAsync(entity, cancellationToken);
		await _dbContext.SaveChangesAsync(cancellationToken);

		// return id of new entity
		return entity.Id;
	}
	#endregion

}