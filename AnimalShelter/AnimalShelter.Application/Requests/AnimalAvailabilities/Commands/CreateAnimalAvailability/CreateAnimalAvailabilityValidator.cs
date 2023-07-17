using FluentValidation;

namespace AnimalShelter.Application.Requests.AnimalAvailabilities.Commands.CreateAnimalAvailability;

public class CreateAnimalAvailabilityValidator : AbstractValidator<CreateAnimalAvailabilityCommand>
{
	public CreateAnimalAvailabilityValidator()
	{
		// check if name is empty
		RuleFor(q => q.Name)
			.NotEmpty()
			.WithMessage("Name is required");

		// check if name is 50 characters
		RuleFor(q => q.Name)
			.Length(2, 50)
			.WithMessage("Name must be between 2 and 50 characters");
	}
}