using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelter.WebApi.Controllers.Base;

/// <summary>
/// Base controller for all controllers in the project
/// </summary>
[ApiController]
[Route("api/[controller]/[action]")]
public abstract class BaseController : ControllerBase
{
	/// <summary>
	/// MediatR sender
	/// </summary>
	protected readonly ISender sender;

	protected BaseController(ISender sender)
	{
		this.sender = sender;
	}
}