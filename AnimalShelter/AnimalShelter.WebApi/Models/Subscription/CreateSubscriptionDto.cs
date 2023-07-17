using AnimalShelter.Application.Common.Mappings;
using AnimalShelter.Application.Requests.Subscriptions.Commands.CreateSubscription;
using AutoMapper;

namespace AnimalShelter.WebApi.Models.Subscription;

/// <summary>
/// DTO for creating a new subscription
/// </summary>
public class CreateSubscriptionDto : IMapWith<CreateSubscriptionCommand>
{
	/// <summary>
	/// Email of the subscriber
	/// </summary>
	public string Email { get; init; } = null!;

	#region IMapWith<CreateSubscriptionCommand> Members
	public void Mapping(Profile profile)
	{
		profile.CreateMap<CreateSubscriptionDto, CreateSubscriptionCommand>();
	}
	#endregion

}