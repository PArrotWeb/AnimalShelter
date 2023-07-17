using AnimalShelter.Application.Common.Exceptions;
using AnimalShelter.Application.Interfaces;
using AnimalShelter.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Application.Requests.Events.Commands.UpdateEvent.UpdateEventPhoto;

/// <summary>
/// Command handler for updating the photo of an event
/// </summary>
public sealed class UpdateEventPhotoCommandHandler : IRequestHandler<UpdateEventPhotoCommand>
{

	private readonly IAnimalShelterDbContext _dbContext;

	public UpdateEventPhotoCommandHandler(IAnimalShelterDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	#region IRequestHandler<UpdateEventPhotoCommand> Members
	public async Task Handle(UpdateEventPhotoCommand request, CancellationToken cancellationToken)
	{
		// find the event to update the photo in the database
		var entity = await _dbContext.Events.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

		// if the event is not found, throw an exception
		if (entity == null)
		{
			throw new NotFoundException(nameof(Event), request.Id);
		}

		// update the photo of the event
		entity.PhotoUrl = request.PhotoUrl;
		await _dbContext.SaveChangesAsync(cancellationToken);
	}
	#endregion

}