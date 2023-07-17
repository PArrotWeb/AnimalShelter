using FluentValidation;

namespace AnimalShelter.Application.Requests.Events.Commands.UpdateEvent.UpdateEventPhoto;

public class UpdateEventPhotoValidator : AbstractValidator<UpdateEventPhotoCommand>
{
	public UpdateEventPhotoValidator()
	{
		// check if Id is empty
		RuleFor(q => q.Id)
			.NotEmpty()
			.WithMessage("Id is required");

		// check if photoUrl is empty
		RuleFor(q => q.PhotoUrl)
			.NotEmpty()
			.WithMessage("PhotoUrl is required");

		// check if photoUrl is 200 characters
		RuleFor(q => q.PhotoUrl)
			.Length(2, 200)
			.WithMessage("PhotoUrl must be between 2 and 200 characters");
	}
}