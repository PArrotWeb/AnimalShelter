using AnimalShelter.Application.Requests.Kinds.Commands.CreateKind;
using AnimalShelter.Application.Requests.Kinds.Commands.DeleteKind;
using AnimalShelter.Application.Requests.Kinds.Queries.GetKinds;
using AnimalShelter.WebApi.Controllers.Base;
using AnimalShelter.WebApi.Models.Kind;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelter.WebApi.Controllers;

/// <summary>
/// Controller for kinds
/// </summary>
[Route("api/[controller]")]
public class KindsController : BaseController
{
	private readonly IMapper _mapper;

	public KindsController(ISender sender, IMapper mapper) : base(sender)
	{
		_mapper = mapper;
	}

	/// <summary>
	/// Get all kinds
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <returns>List of all kinds</returns>
	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<ActionResult<KindsVm>> GetAll(CancellationToken cancellationToken)
	{
		// send query to mediator
		var query = new GetKindsQuery();
		var vm = await sender.Send(query, cancellationToken);

		return Ok(vm);
	}

	/// <summary>
	/// Create new kind
	/// </summary>
	/// <param name="dto"></param>
	/// <returns>Id of new kind</returns>
	[HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created)]
	public async Task<ActionResult<Guid>> Create([FromBody] CreateKindDto dto)
	{
		// map dto to command and send command to mediator
		var command = _mapper.Map<CreateKindCommand>(dto);
		var entityId = await sender.Send(command);
		return Ok(entityId);
	}

	/// <summary>
	/// Delete kind by id
	/// </summary>
	/// <param name="id"></param>
	/// <returns>Id of kind to delete</returns>
	[HttpDelete("{id}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	public async Task<IActionResult> Delete(Guid id)
	{
		// send command to mediator
		var command = new DeleteKindCommand
		{
			Id = id
		};
		await sender.Send(command);

		return NoContent();
	}
}