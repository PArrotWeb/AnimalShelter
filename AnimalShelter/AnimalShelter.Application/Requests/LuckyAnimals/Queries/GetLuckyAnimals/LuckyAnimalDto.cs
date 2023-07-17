using AnimalShelter.Application.Common.Mappings;
using AnimalShelter.Application.Requests.Animals.Queries.GetAnimals;
using AnimalShelter.Domain.Entities;
using AutoMapper;

namespace AnimalShelter.Application.Requests.LuckyAnimals.Queries.GetLuckyAnimals;

/// <summary>
/// Represents data transfer object for <see cref="LuckyAnimal" /> model
/// </summary>
public sealed class LuckyAnimalDto : IMapWith<LuckyAnimal>
{
	/// <summary>
	/// Id of the lucky animal
	/// </summary>
	public Guid Id { get; init; }

	/// <summary>
	/// Url to the photo of the lucky animal
	/// </summary>
	public string PhotoUrl { get; init; } = null!;

	/// <summary>
	/// Comment about the lucky animal
	/// </summary>
	public string? Comment { get; init; }

	/// <summary>
	/// Date of adoption of the lucky animal
	/// </summary>
	public DateTime AdoptionDate { get; init; }

	/// <summary>
	/// Animal data
	/// </summary>
	public AnimalDto Animal { get; init; } = null!;

	#region IMapWith<LuckyAnimal> Members
	public void Mapping(Profile profile)
	{
		profile.CreateMap<LuckyAnimal, LuckyAnimalDto>();
	}
	#endregion

}