using AnimalShelter.Application.Requests.LuckyAnimals.Commands.CreateLuckyAnimal;
using AnimalShelter.Application.Requests.LuckyAnimals.Commands.UpdateLuckyAnimal.UpdateLuckyAnimalPhoto;
using AnimalShelter.Application.Requests.LuckyAnimals.Queries.GetLuckyAnimals;
using AnimalShelter.WebApi.Controllers.Base;
using AnimalShelter.WebApi.Models.LuckyAnimal;
using AnimalShelter.WebApi.Services.Upload;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelter.WebApi.Controllers;

/// <summary>
/// Controller for lucky animals
/// </summary>
[Route("api/[controller]")]
public class LuckyAnimalsController : BaseController
{
	private readonly IMapper _mapper;
	private readonly IUploadService _uploadService;

	public LuckyAnimalsController(ISender sender, IMapper mapper, IUploadService uploadService) : base(sender)
	{
		_mapper = mapper;
		_uploadService = uploadService;
	}

	/// <summary>
	/// Get all lucky animals
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <returns>List of all lucky animals</returns>
	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<ActionResult<LuckyAnimalsVm>> GetAll(CancellationToken cancellationToken)
	{
		// send query to mediator
		var query = new GetLuckyAnimalsQuery();
		var vm = await sender.Send(query, cancellationToken);

		return Ok(vm);
	}

	/// <summary>
	/// Create new lucky animal
	/// </summary>
	/// <param name="dto"></param>
	/// <returns>Id of new animal</returns>
	[HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created)]
	public async Task<ActionResult<Guid>> Create([FromBody] CreateLuckyAnimalsDto dto)
	{
		// map dto to command and send command to mediator
		var command = _mapper.Map<CreateOrderCommand>(dto);
		var entityId = await sender.Send(command);

		// save photo to server
		var folder = Path.Combine("images", "lucky_animals");
		var filePath = await _uploadService.SaveFileAsync(dto.PhotoBase64, entityId.ToString(), folder);

		// update photo url
		var updatePhotoCommand = new UpdateLuckyAnimalPhotoCommand
		{
			Id = entityId,
			PhotoUrl = filePath
		};
		await sender.Send(updatePhotoCommand);

		return Ok(entityId);
	}
}