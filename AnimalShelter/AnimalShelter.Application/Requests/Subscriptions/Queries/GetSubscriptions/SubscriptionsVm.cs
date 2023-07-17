namespace AnimalShelter.Application.Requests.Subscriptions.Queries.GetSubscriptions;

/// <summary>
/// View model for <see cref="GetSubscriptionsQuery" />
/// </summary>
/// <param name="Subscriptions"></param>
public sealed record SubscriptionsVm(IList<SubscriptionDto> Subscriptions);