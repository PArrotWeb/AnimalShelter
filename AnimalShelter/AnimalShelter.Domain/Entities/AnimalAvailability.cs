namespace AnimalShelter.Domain.Entities;

/// <summary>
/// Specifies the availability of an animal
/// </summary>
public class AnimalAvailability
{
	/// <summary>
	/// Id of the availability
	/// </summary>
	public Guid Id { get; set; }

	/// <summary>
	/// Name of the availability
	/// </summary>
	public string Name { get; set; } = null!;

	/// <summary>
	/// Animals with this availability
	/// </summary>
	public ICollection<Animal> Animals { get; set; } = null!;
}