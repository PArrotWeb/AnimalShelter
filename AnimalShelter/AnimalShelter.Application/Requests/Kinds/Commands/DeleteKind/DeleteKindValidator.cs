using FluentValidation;

namespace AnimalShelter.Application.Requests.Kinds.Commands.DeleteKind;

public class DeleteKindValidator : AbstractValidator<DeleteKindCommand>
{
	public DeleteKindValidator()
	{
		// check if name is empty
		RuleFor(q => q.Id)
			.NotEmpty()
			.WithMessage("Id is required");
	}
}