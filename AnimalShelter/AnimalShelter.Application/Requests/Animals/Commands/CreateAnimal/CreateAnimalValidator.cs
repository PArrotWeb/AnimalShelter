using FluentValidation;

namespace AnimalShelter.Application.Requests.Animals.Commands.CreateAnimal;

public class CreateAnimalValidator : AbstractValidator<CreateAnimalCommand>
{
	public CreateAnimalValidator()
	{
		// check if name is empty
		RuleFor(q => q.Name)
			.NotEmpty()
			.WithMessage("Name is required");

		// check if name is 50 characters
		RuleFor(q => q.Name)
			.Length(2, 50)
			.WithMessage("Name must be between 2 and 50 characters");

		// check if description is 450 characters
		RuleFor(q => q.Description)
			.MaximumLength(450)
			.WithMessage("Description must not exceed 450 characters");

		// check if descriptionExtra is 450 characters
		RuleFor(q => q.DescriptionExtra)
			.MaximumLength(450)
			.WithMessage("DescriptionExtra must not exceed 450 characters");

		// check if history is 450 characters
		RuleFor(q => q.History)
			.MaximumLength(450)
			.WithMessage("History must not exceed 450 characters");

		// check if admissionDate is empty
		RuleFor(q => q.AdmissionDate)
			.NotEmpty()
			.WithMessage("AdmissionDate is required");

		// check if height is empty
		RuleFor(q => q.Height)
			.NotEmpty()
			.WithMessage("Height is required");

		// check if height is greater than 0
		RuleFor(q => q.Height)
			.GreaterThan(0)
			.WithMessage("Height must be greater than 0");

		// check if weight is empty
		RuleFor(q => q.Weight)
			.NotEmpty()
			.WithMessage("Weight is required");

		// check if weight is greater than 0
		RuleFor(q => q.Weight)
			.GreaterThan(0)
			.WithMessage("Weight must be greater than 0");

		// check if kindId is empty
		RuleFor(q => q.KindId)
			.NotEmpty()
			.WithMessage("KindId is required");

		// check if animalAvailabilityId is empty
		RuleFor(q => q.AnimalAvailabilityId)
			.NotEmpty()
			.WithMessage("AnimalAvailabilityId is required");
	}
}