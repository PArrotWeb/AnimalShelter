using AnimalShelter.Application.Common.Mappings;
using AnimalShelter.Application.Requests.AnimalAvailabilities.Commands.CreateAnimalAvailability;
using AutoMapper;

namespace AnimalShelter.WebApi.Models.AnimalAvailability;

/// <summary>
/// DTO for creating a new animal availability
/// </summary>
public class CreateAnimalAvailabilityDto : IMapWith<CreateAnimalAvailabilityCommand>
{
	/// <summary>
	/// Name of the animal availability
	/// </summary>
	public string Name { get; init; } = null!;

	#region IMapWith<CreateAnimalAvailabilityCommand> Members
	public void Mapping(Profile profile)
	{
		profile.CreateMap<CreateAnimalAvailabilityDto, CreateAnimalAvailabilityCommand>();
	}
	#endregion

}