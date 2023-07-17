using FluentValidation;

namespace AnimalShelter.Application.Requests.Events.Commands.DeleteEvent;

public class DeleteEventValidator : AbstractValidator<DeleteEventCommand>
{
	public DeleteEventValidator()
	{
		// check if name is empty
		RuleFor(q => q.Id)
			.NotEmpty()
			.WithMessage("Id is required");
	}
}