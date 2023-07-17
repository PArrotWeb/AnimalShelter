namespace AnimalShelter.Domain.Entities;

/// <summary>
/// User subscription to news
/// </summary>
public class Subscription
{
	/// <summary>
	/// Id of subscription
	/// </summary>
	public Guid Id { get; set; }

	/// <summary>
	/// Email of subscriber
	/// </summary>
	public string Email { get; set; } = null!;
}