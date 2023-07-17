namespace AnimalShelter.Domain.Entities;

/// <summary>
/// Order for animal
/// </summary>
public class Order
{
	/// <summary>
	/// Id of order
	/// </summary>
	public Guid Id { get; set; }

	/// <summary>
	/// Orderer name
	/// </summary>
	public string Name { get; set; } = null!;

	/// <summary>
	/// Orderer phone
	/// </summary>
	public string Phone { get; set; } = null!;

	/// <summary>
	/// Orderer email
	/// </summary>
	public string Email { get; set; } = null!;

	/// <summary>
	/// Planned date of pickup animal
	/// </summary>
	public DateTime PlannedDate { get; set; }

	/// <summary>
	/// Comment of orderer
	/// </summary>
	public string? Comment { get; set; } = null!;

	/// <summary>
	/// Id of animal
	/// </summary>
	public Guid AnimalId { get; set; }

	/// <summary>
	/// Animal
	/// </summary>
	public Animal Animal { get; set; } = null!;
}