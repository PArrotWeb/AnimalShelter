using AnimalShelter.Application.Common.Exceptions;
using AnimalShelter.Application.Interfaces;
using AnimalShelter.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Application.Requests.LuckyAnimals.Commands.UpdateLuckyAnimal.UpdateLuckyAnimalPhoto;

/// <summary>
/// Command handler for updating lucky animal photo
/// </summary>
public sealed class UpdateLuckyAnimalPhotoCommandHandler : IRequestHandler<UpdateLuckyAnimalPhotoCommand>
{

	private readonly IAnimalShelterDbContext _dbContext;

	public UpdateLuckyAnimalPhotoCommandHandler(IAnimalShelterDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	#region IRequestHandler<UpdateLuckyAnimalPhotoCommand> Members
	public async Task Handle(UpdateLuckyAnimalPhotoCommand request, CancellationToken cancellationToken)
	{
		// find entity by id in database
		var entity = await _dbContext.LuckyAnimals.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

		// check if entity not found
		if (entity == null)
		{
			throw new NotFoundException(nameof(LuckyAnimal), request.Id);
		}

		// update entity photo url in database
		entity.PhotoUrl = request.PhotoUrl;
		await _dbContext.SaveChangesAsync(cancellationToken);
	}
	#endregion

}