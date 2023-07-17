using MediatR;

namespace AnimalShelter.Application.Requests.Subscriptions.Commands.CreateSubscription;

/// <summary>
/// Command for creating a new subscription
/// </summary>
public sealed record CreateSubscriptionCommand : IRequest<Guid>
{
	/// <summary>
	/// Email of the subscriber
	/// </summary>
	public string Email { get; init; } = null!;
}