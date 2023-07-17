using FluentValidation;

namespace AnimalShelter.Application.Requests.AnimalAvailabilities.Commands.DeleteAnimalAvailability;

public class DeleteAnimalAvailabilityValidator : AbstractValidator<DeleteAnimalAvailabilityCommand>
{
	public DeleteAnimalAvailabilityValidator()
	{
		// check if name is empty
		RuleFor(q => q.Id)
			.NotEmpty()
			.WithMessage("Id is required");
	}
}