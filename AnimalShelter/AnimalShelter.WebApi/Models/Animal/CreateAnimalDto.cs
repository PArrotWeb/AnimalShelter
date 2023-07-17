using AnimalShelter.Application.Common.Mappings;
using AnimalShelter.Application.Requests.Animals.Commands.CreateAnimal;
using AutoMapper;

namespace AnimalShelter.WebApi.Models.Animal;

/// <summary>
/// DTO for creating an animal
/// </summary>
public class CreateAnimalDto : IMapWith<CreateAnimalCommand>
{
	/// <summary>
	/// Base64 encoded photo of animal
	/// </summary>
	public string PhotoBase64 { get; init; } = null!;

	/// <summary>
	/// Name of the animal
	/// </summary>
	public string Name { get; init; } = null!;

	/// <summary>
	/// Description of the animal
	/// </summary>
	public string? Description { get; init; } = null!;

	/// <summary>
	/// Extra description of the animal
	/// </summary>
	public string? DescriptionExtra { get; init; } = null!;

	/// <summary>
	/// Admission history of the animal
	/// </summary>
	public string? History { get; init; } = null!;

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

	#region IMapWith<CreateAnimalCommand> Members
	public void Mapping(Profile profile)
	{
		profile.CreateMap<CreateAnimalDto, CreateAnimalCommand>()
			.ForMember(d => d.PhotoUrl, o => o.Ignore());
	}
	#endregion

}