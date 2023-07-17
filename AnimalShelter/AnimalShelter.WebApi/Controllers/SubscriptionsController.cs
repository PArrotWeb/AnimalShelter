using AnimalShelter.Application.Requests.Subscriptions.Commands.CreateSubscription;
using AnimalShelter.Application.Requests.Subscriptions.Queries.GetSubscriptions;
using AnimalShelter.WebApi.Controllers.Base;
using AnimalShelter.WebApi.Models.Subscription;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelter.WebApi.Controllers;

/// <summary>
/// Controller for subscriptions
/// </summary>
[Route("api/[controller]")]
public class SubscriptionsController : BaseController
{
	private readonly IMapper _mapper;

	public SubscriptionsController(ISender sender, IMapper mapper) : base(sender)
	{
		_mapper = mapper;
	}

	/// <summary>
	/// Get all subscriptions
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <returns>List of all subscriptions</returns>
	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<ActionResult<SubscriptionsVm>> GetAll(CancellationToken cancellationToken)
	{
		// send query to mediator
		var query = new GetSubscriptionsQuery();
		var vm = await sender.Send(query, cancellationToken);

		return Ok(vm);
	}

	/// <summary>
	/// Create new subscription
	/// </summary>
	/// <param name="dto"></param>
	/// <returns>Id of new subscription</returns>
	[HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created)]
	public async Task<ActionResult<Guid>> Create([FromBody] CreateSubscriptionDto dto)
	{
		// map dto to command and send it to mediator
		var command = _mapper.Map<CreateSubscriptionCommand>(dto);
		var entityId = await sender.Send(command);

		return Ok(entityId);
	}
}