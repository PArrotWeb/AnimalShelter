using FluentValidation;

namespace AnimalShelter.Application.Requests.Events.Commands.CreateEvent;

public class CreateEventValidator : AbstractValidator<CreateEventCommand>
{
	public CreateEventValidator()
	{
		// check if description is empty
		RuleFor(q => q.Description)
			.NotEmpty()
			.WithMessage("Description is required");

		// check if description is between 2 and 450 characters
		RuleFor(q => q.Description)
			.Length(2, 450)
			.WithMessage("Description must be between 2 and 450 characters");

		// check if link maximum length is 200 characters
		RuleFor(q => q.Link)
			.MaximumLength(200)
			.WithMessage("Link must not exceed 200 characters");
	}
}