using FluentValidation;

namespace AnimalShelter.Application.Requests.Orders.Commands.DeleteOrder;

public class DeleteOrderValidator : AbstractValidator<DeleteOrderCommand>
{
	public DeleteOrderValidator()
	{
		// check if Id is empty
		RuleFor(q => q.Id)
			.NotEmpty()
			.WithMessage("Id is required");
	}
}