using FluentValidation;

namespace AnimalShelter.Application.Requests.Subscriptions.Commands.CreateSubscription;

public class CreateSubscriptionValidator : AbstractValidator<CreateSubscriptionCommand>
{
	public CreateSubscriptionValidator()
	{
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
	}
}