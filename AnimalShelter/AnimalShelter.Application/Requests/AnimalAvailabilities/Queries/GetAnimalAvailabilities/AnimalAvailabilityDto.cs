using AnimalShelter.Application.Common.Mappings;
using AnimalShelter.Domain.Entities;
using AutoMapper;

namespace AnimalShelter.Application.Requests.AnimalAvailabilities.Queries.GetAnimalAvailabilities;

/// <summary>
/// Represents data transfer object for <see cref="AnimalAvailability" /> model.
/// </summary>
public sealed class AnimalAvailabilityDto : IMapWith<AnimalAvailability>
{
	/// <summary>
	/// Id of animal availability
	/// </summary>
	public Guid Id { get; init; }

	/// <summary>
	/// Name of animal availability
	/// </summary>
	public string Name { get; init; } = null!;

	#region IMapWith<AnimalAvailability> Members
	public void Mapping(Profile profile)
	{
		profile.CreateMap<AnimalAvailability, AnimalAvailabilityDto>();
	}
	#endregion

}