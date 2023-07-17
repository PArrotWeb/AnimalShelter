using FluentValidation;

namespace AnimalShelter.Application.Requests.Orders.Commands.CreateOrder;

public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
{
	public CreateOrderValidator()
	{
		// check if name is empty
		RuleFor(q => q.Name)
			.NotEmpty()
			.WithMessage("Name is required");

		// check if name is 50 characters
		RuleFor(q => q.Name)
			.Length(2, 50)
			.WithMessage("Name must be between 2 and 50 characters");

		// check if phone is empty
		RuleFor(q => q.Phone)
			.NotEmpty()
			.WithMessage("Phone is required");

		// check if phone is a valid phone number
		RuleFor(q => q.Phone)
			.Matches(@"^(\+[0-9]{2-15})$")
			.WithMessage("Phone must be a valid phone number");

		// check if email is empty
		RuleFor(q => q.Email)
			.NotEmpty()
			.WithMessage("Email is required");

		// check if email is 256 characters
		RuleFor(q => q.Email)
			.Length(2, 256)
			.WithMessage("Email must be between 2 and 256 characters");

		// check if email is a valid email address
		RuleFor(q => q.Email)
			.EmailAddress()
			.WithMessage("Email must be a valid email address");

		// check if planned date is empty
		RuleFor(q => q.PlannedDate)
			.NotEmpty()
			.WithMessage("PlannedDate is required");

		// check if comment is 450 characters
		RuleFor(q => q.Comment)
			.MaximumLength(450)
			.WithMessage("Comment must not exceed 450 characters");

		// check if AnimalId is empty
		RuleFor(q => q.AnimalId)
			.NotEmpty()
			.WithMessage("AnimalId is required");
	}
}