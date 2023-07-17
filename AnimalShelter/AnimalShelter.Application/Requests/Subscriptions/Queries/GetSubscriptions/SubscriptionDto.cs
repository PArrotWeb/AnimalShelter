using AnimalShelter.Application.Common.Mappings;
using AnimalShelter.Domain.Entities;
using AutoMapper;

namespace AnimalShelter.Application.Requests.Subscriptions.Queries.GetSubscriptions;

/// <summary>
/// Represents data transfer object for <see cref="Subscription" />
/// </summary>
public sealed class SubscriptionDto : IMapWith<Subscription>
{
	/// <summary>
	/// Id of the subscription
	/// </summary>
	public Guid Id { get; init; }

	/// <summary>
	/// Email of the subscriber
	/// </summary>
	public string Email { get; init; } = null!;

	#region IMapWith<Subscription> Members
	public void Mapping(Profile profile)
	{
		profile.CreateMap<Subscription, SubscriptionDto>();
	}
	#endregion

}