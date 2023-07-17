namespace AnimalShelter.Domain.Entities;

/// <summary>
/// Kind of animal
/// </summary>
public class Kind
{
	/// <summary>
	/// Id of kind
	/// </summary>
	public Guid Id { get; set; }

	/// <summary>
	/// Name of kind
	/// </summary>
	public string Name { get; set; } = null!;

	/// <summary>
	/// Animals with this kind
	/// </summary>
	public ICollection<Animal> Animals { get; set; } = null!;
}