using MediatR;

namespace AnimalShelter.Application.Requests.Kinds.Commands.DeleteKind;

/// <summary>
/// Command for deleting a kind
/// </summary>
public sealed record DeleteKindCommand : IRequest
{
	/// <summary>
	/// Id of the kind to delete
	/// </summary>
	public Guid Id { get; init; }
}