using FluentValidation;

namespace AnimalShelter.Application.Requests.LuckyAnimals.Commands.CreateLuckyAnimal;

public class CreateLuckyAnimalValidator : AbstractValidator<CreateOrderCommand>
{
	public CreateLuckyAnimalValidator()
	{
		// check if comment is 450 characters
		RuleFor(q => q.Comment)
			.MaximumLength(450)
			.WithMessage("Comment must not exceed 450 characters");

		// check if AdoptionDate is empty
		RuleFor(q => q.AdoptionDate)
			.NotEmpty()
			.WithMessage("AdoptionDate is required");

		// check if AnimalId is empty
		RuleFor(q => q.AnimalId)
			.NotEmpty()
			.WithMessage("AnimalId is required");
	}
}