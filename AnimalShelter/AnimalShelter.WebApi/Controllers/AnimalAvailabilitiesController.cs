using AnimalShelter.Application.Requests.AnimalAvailabilities.Commands.CreateAnimalAvailability;
using AnimalShelter.Application.Requests.AnimalAvailabilities.Commands.DeleteAnimalAvailability;
using AnimalShelter.Application.Requests.AnimalAvailabilities.Queries.GetAnimalAvailabilities;
using AnimalShelter.WebApi.Controllers.Base;
using AnimalShelter.WebApi.Models.AnimalAvailability;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelter.WebApi.Controllers;

/// <summary>
/// Controller for animal availabilities
/// </summary>
[Route("api/[controller]")]
public class AnimalAvailabilitiesController : BaseController
{
	private readonly IMapper _mapper;

	public AnimalAvailabilitiesController(ISender sender, IMapper mapper) : base(sender)
	{
		_mapper = mapper;
	}

	/// <summary>
	/// Get all animal availabilities
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <returns>List of animal availabilities</returns>
	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<ActionResult<AnimalAvailabilitiesVm>> GetAll(CancellationToken cancellationToken)
	{
		// send query to mediator
		var query = new GetAnimalAvailabilitiesQuery();
		var vm = await sender.Send(query, cancellationToken);

		return Ok(vm);
	}

	/// <summary>
	/// Create new animal availability
	/// </summary>
	/// <param name="dto"></param>
	/// <returns>Id of new animal availability</returns>
	[HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created)]
	public async Task<ActionResult<Guid>> Create([FromBody] CreateAnimalAvailabilityDto dto)
	{
		// map dto to command and send it to mediator
		var command = _mapper.Map<CreateAnimalAvailabilityCommand>(dto);
		var entityId = await sender.Send(command);

		return Ok(entityId);
	}

	/// <summary>
	/// Delete animal availability by Id
	/// </summary>
	/// <param name="id">Id of animal availability</param>
	/// <returns></returns>
	[HttpDelete("{id}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	public async Task<IActionResult> Delete(Guid id)
	{
		// send command to mediator
		var command = new DeleteAnimalAvailabilityCommand
		{
			Id = id
		};
		await sender.Send(command);

		return NoContent();
	}
}