using AnimalShelter.Application.Common.Exceptions;
using AnimalShelter.Application.Interfaces;
using AnimalShelter.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Application.Requests.Animals.Commands.UpdateAnimal.UpdateAnimalPhoto;

/// <summary>
/// Command handler for updating animal photo
/// </summary>
public sealed class UpdateAnimalPhotoCommandHandler : IRequestHandler<UpdateAnimalPhotoCommand>
{

	private readonly IAnimalShelterDbContext _dbContext;

	public UpdateAnimalPhotoCommandHandler(IAnimalShelterDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	#region IRequestHandler<UpdateAnimalPhotoCommand> Members
	public async Task Handle(UpdateAnimalPhotoCommand request, CancellationToken cancellationToken)
	{
		// get entity from database
		var entity = await _dbContext.Animals.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

		// check if entity not found
		if (entity == null)
		{
			throw new NotFoundException(nameof(Animal), request.Id);
		}

		// update entity
		entity.PhotoUrl = request.PhotoUrl;
		await _dbContext.SaveChangesAsync(cancellationToken);
	}
	#endregion

}