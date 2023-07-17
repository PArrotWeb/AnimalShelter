using MediatR;

namespace AnimalShelter.Application.Requests.Subscriptions.Queries.GetSubscriptions;

/// <summary>
/// Query for getting all subscriptions
/// </summary>
public record GetSubscriptionsQuery : IRequest<SubscriptionsVm>;