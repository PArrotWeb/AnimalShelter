namespace AnimalShelter.Domain.Entities;

/// <summary>
/// Animal entity
/// </summary>
public class Animal
{
	/// <summary>
	/// Id of animal
	/// </summary>
	public Guid Id { get; set; }

	/// <summary>
	/// Url of animal photo
	/// </summary>
	public string PhotoUrl { get; set; } = null!;

	/// <summary>
	/// Name of animal
	/// </summary>
	public string Name { get; set; } = null!;

	/// <summary>
	/// Description of animal
	/// </summary>
	public string? Description { get; set; } = null!;

	/// <summary>
	/// Extra description of animal
	/// </summary>
	public string? DescriptionExtra { get; set; } = null!;

	/// <summary>
	/// Admission history of animal
	/// </summary>
	public string? History { get; set; } = null!;

	/// <summary>
	/// Admission date of animal
	/// </summary>
	public DateTime AdmissionDate { get; set; }

	/// <summary>
	/// Height of animal
	/// </summary>
	public float Height { get; set; }

	/// <summary>
	/// Weight of animal
	/// </summary>
	public float Weight { get; set; }

	/// <summary>
	/// Id of animal kind
	/// </summary>
	public Guid KindId { get; set; }

	/// <summary>
	/// Animal kind
	/// </summary>
	public Kind Kind { get; set; } = null!;

	/// <summary>
	/// Id of animal availability
	/// </summary>
	public Guid AnimalAvailabilityId { get; set; }

	/// <summary>
	/// Animal availability
	/// </summary>
	public AnimalAvailability AnimalAvailability { get; set; } = null!;

	/// <summary>
	/// Orders of animal
	/// </summary>
	public ICollection<Order> Orders { get; set; } = null!;

	/// <summary>
	/// Feedback of animal
	/// </summary>
	public LuckyAnimal LuckyAnimal { get; set; } = null!;
}