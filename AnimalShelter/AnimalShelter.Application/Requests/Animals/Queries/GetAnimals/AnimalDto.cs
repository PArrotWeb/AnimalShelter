using AnimalShelter.Application.Common.Mappings;
using AnimalShelter.Domain.Entities;
using AutoMapper;

namespace AnimalShelter.Application.Requests.Animals.Queries.GetAnimals;

/// <summary>
/// Data transfer object for <see cref="Animal" /> model
/// </summary>
public sealed class AnimalDto : IMapWith<Animal>
{
	/// <summary>
	/// Id of the animal
	/// </summary>
	public Guid Id { get; init; }

	/// <summary>
	/// Url of the photo of the animal
	/// </summary>
	public string PhotoUrl { get; init; } = null!;

	/// <summary>
	/// Name of the animal
	/// </summary>
	public string Name { get; init; } = null!;

	/// <summary>
	/// Description of the animal
	/// </summary>
	public string? Description { get; init; }

	/// <summary>
	/// Extra description of the animal
	/// </summary>
	public string? DescriptionExtra { get; init; }

	/// <summary>
	/// Admission history of the animal
	/// </summary>
	public string? History { get; init; }

	/// <summary>
	/// Date of admission of the animal
	/// </summary>
	public DateTime AdmissionDate { get; init; }

	/// <summary>
	/// Height of the animal
	/// </summary>
	public float Height { get; init; }

	/// <summary>
	/// Weight of the animal
	/// </summary>
	public float Weight { get; init; }

	/// <summary>
	/// Id of the Kind of the animal
	/// </summary>
	public Guid KindId { get; init; }

	/// <summary>
	/// Id of the AnimalAvailability of the animal
	/// </summary>
	public Guid AnimalAvailabilityId { get; init; }

	#region IMapWith<Animal> Members
	public void Mapping(Profile profile)
	{
		profile.CreateMap<Animal, AnimalDto>();
	}
	#endregion

}