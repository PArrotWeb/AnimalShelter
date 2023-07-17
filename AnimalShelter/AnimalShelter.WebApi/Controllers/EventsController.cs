using AnimalShelter.Application.Requests.Events.Commands.CreateEvent;
using AnimalShelter.Application.Requests.Events.Commands.DeleteEvent;
using AnimalShelter.Application.Requests.Events.Commands.UpdateEvent.UpdateEventPhoto;
using AnimalShelter.Application.Requests.Events.Queries.GetEvents;
using AnimalShelter.WebApi.Controllers.Base;
using AnimalShelter.WebApi.Models.Event;
using AnimalShelter.WebApi.Services.Upload;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelter.WebApi.Controllers;

/// <summary>
/// Controller for events
/// </summary>
[Route("api/[controller]")]
public class EventsController : BaseController
{
	private readonly IMapper _mapper;
	private readonly IUploadService _uploadService;

	public EventsController(ISender sender, IMapper mapper, IUploadService uploadService) : base(sender)
	{
		_mapper = mapper;
		_uploadService = uploadService;
	}

	/// <summary>
	/// Get all events
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <returns>List of all events</returns>
	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<ActionResult<EventsVm>> GetAll(CancellationToken cancellationToken)
	{
		// send query to mediator
		var query = new GetEventsQuery();
		var vm = await sender.Send(query, cancellationToken);

		return Ok(vm);
	}

	/// <summary>
	/// Create new event
	/// </summary>
	/// <param name="dto"></param>
	/// <returns>Id of new event</returns>
	[HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created)]
	public async Task<ActionResult<Guid>> Create([FromBody] CreateEventDto dto)
	{
		// map dto to command and send command to mediator
		var command = _mapper.Map<CreateEventCommand>(dto);
		var entityId = await sender.Send(command);

		// save photo to server
		var folder = Path.Combine("images", "events");
		var filePath = await _uploadService.SaveFileAsync(dto.PhotoBase64, entityId.ToString(), folder);

		// update photo url
		var updatePhotoCommand = new UpdateEventPhotoCommand
		{
			Id = entityId,
			PhotoUrl = filePath
		};
		await sender.Send(updatePhotoCommand);

		return Ok(entityId);
	}

	/// <summary>
	/// Delete event by Id
	/// </summary>
	/// <param name="id">Id of event to delete</param>
	/// <returns></returns>
	[HttpDelete("{id}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	public async Task<IActionResult> Delete(Guid id)
	{
		// send command to mediator
		var command = new DeleteEventCommand
		{
			Id = id
		};
		await sender.Send(command);

		return NoContent();
	}
}