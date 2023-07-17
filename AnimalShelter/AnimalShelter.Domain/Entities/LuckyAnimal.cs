namespace AnimalShelter.Domain.Entities;

/// <summary>
/// FeedBack for animal
/// </summary>
public class LuckyAnimal
{
	/// <summary>
	/// Id of lucky animal
	/// </summary>
	public Guid Id { get; set; }

	/// <summary>
	/// Url of photo of lucky animal
	/// </summary>
	public string PhotoUrl { get; set; } = null!;

	/// <summary>
	/// Feedback of lucky animal
	/// </summary>
	public string? Comment { get; set; }

	/// <summary>
	/// Date of adoption of animal
	/// </summary>
	public DateTime AdoptionDate { get; set; }

	/// <summary>
	/// Id of animal
	/// </summary>
	public Guid AnimalId { get; set; }

	/// <summary>
	/// Animal
	/// </summary>
	public Animal Animal { get; set; } = null!;
}