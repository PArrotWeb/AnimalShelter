using MediatR;

namespace AnimalShelter.Application.Requests.Kinds.Commands.CreateKind;

/// <summary>
/// Command for creating a new kind
/// </summary>
public sealed record CreateKindCommand : IRequest<Guid>
{
	/// <summary>
	/// Name of the new kind
	/// </summary>
	public string Name { get; init; } = null!;
}