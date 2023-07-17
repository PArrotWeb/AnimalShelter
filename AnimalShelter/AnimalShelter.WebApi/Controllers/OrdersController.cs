using AnimalShelter.Application.Requests.Orders.Commands.CreateOrder;
using AnimalShelter.Application.Requests.Orders.Commands.DeleteOrder;
using AnimalShelter.Application.Requests.Orders.Queries.GetOrders;
using AnimalShelter.WebApi.Controllers.Base;
using AnimalShelter.WebApi.Models.Order;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelter.WebApi.Controllers;

/// <summary>
/// Controller for orders
/// </summary>
[Route("api/[controller]")]
public class OrdersController : BaseController
{
	private readonly IMapper _mapper;

	public OrdersController(ISender sender, IMapper mapper) : base(sender)
	{
		_mapper = mapper;
	}

	/// <summary>
	/// Get all orders
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <returns>List of all orders</returns>
	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<ActionResult<OrdersVm>> GetAll(CancellationToken cancellationToken)
	{
		// send query to mediator
		var query = new GetOrdersQuery();
		var vm = await sender.Send(query, cancellationToken);

		return Ok(vm);
	}

	/// <summary>
	/// Create new order
	/// </summary>
	/// <param name="dto"></param>
	/// <returns>Id of new order</returns>
	[HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created)]
	public async Task<ActionResult<Guid>> Create([FromBody] CreateOrderDto dto)
	{
		// map dto to command and send it to mediator
		var command = _mapper.Map<CreateOrderCommand>(dto);
		var entityId = await sender.Send(command);

		return Ok(entityId);
	}

	/// <summary>
	/// Delete order by id
	/// </summary>
	/// <param name="id">Id of order to delete</param>
	/// <returns></returns>
	[HttpDelete("{id}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	public async Task<IActionResult> Delete(Guid id)
	{
		// send command to mediator
		var command = new DeleteOrderCommand
		{
			Id = id
		};
		await sender.Send(command);

		return NoContent();
	}
}