using FluentValidation;

namespace AnimalShelter.Application.Requests.Animals.Commands.DeleteAnimal;

public class DeleteAnimalValidator : AbstractValidator<DeleteAnimalCommand>
{
	public DeleteAnimalValidator()
	{
		// check if Id is empty
		RuleFor(q => q.Id)
			.NotEmpty()
			.WithMessage("Id is required");
	}
}