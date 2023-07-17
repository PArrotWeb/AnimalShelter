using AnimalShelter.Application.Requests.Animals.Commands.CreateAnimal;
using AnimalShelter.Application.Requests.Animals.Commands.DeleteAnimal;
using AnimalShelter.Application.Requests.Animals.Commands.UpdateAnimal.UpdateAnimalPhoto;
using AnimalShelter.Application.Requests.Animals.Queries.GetAnimals;
using AnimalShelter.WebApi.Controllers.Base;
using AnimalShelter.WebApi.Models.Animal;
using AnimalShelter.WebApi.Services.Upload;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelter.WebApi.Controllers;

/// <summary>
/// Controller for animals
/// </summary>
[Route("api/[controller]")]
public class AnimalsController : BaseController
{
	private readonly IMapper _mapper;
	private readonly IUploadService _uploadService;

	public AnimalsController(ISender sender, IMapper mapper, IUploadService uploadService) : base(sender)
	{
		_mapper = mapper;
		_uploadService = uploadService;
	}

	/// <summary>
	/// Get all animals
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <returns>List of all animals</returns>
	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<ActionResult<AnimalsVm>> GetAll(CancellationToken cancellationToken)
	{
		// send query to mediator
		var query = new GetAnimalsQuery();
		var vm = await sender.Send(query, cancellationToken);

		return Ok(vm);
	}

	/// <summary>
	/// Create new animal
	/// </summary>
	/// <param name="dto"></param>
	/// <returns>Id of new animal</returns>
	[HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created)]
	public async Task<ActionResult<Guid>> Create([FromBody] CreateAnimalDto dto)
	{
		// map dto to command and send it to mediator
		var command = _mapper.Map<CreateAnimalCommand>(dto);
		var entityId = await sender.Send(command);

		// save photo to server
		var folder = Path.Combine("images", "animals");
		var filePath = await _uploadService.SaveFileAsync(dto.PhotoBase64, entityId.ToString(), folder);

		// update photo url
		var updatePhotoCommand = new UpdateAnimalPhotoCommand
		{
			Id = entityId,
			PhotoUrl = filePath
		};
		await sender.Send(updatePhotoCommand);

		return Ok(entityId);
	}

	/// <summary>
	/// Delete animal by Id
	/// </summary>
	/// <param name="id">Id of animal to delete</param>
	/// <returns></returns>
	[HttpDelete("{id}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	public async Task<IActionResult> Delete(Guid id)
	{
		// send command to mediator
		var command = new DeleteAnimalCommand
		{
			Id = id
		};
		await sender.Send(command);

		return NoContent();
	}
}