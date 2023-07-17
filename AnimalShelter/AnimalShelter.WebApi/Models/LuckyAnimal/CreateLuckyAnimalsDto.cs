using AnimalShelter.Application.Common.Mappings;
using AnimalShelter.Application.Requests.LuckyAnimals.Commands.CreateLuckyAnimal;
using AutoMapper;

namespace AnimalShelter.WebApi.Models.LuckyAnimal;

/// <summary>
/// DTO for creating a new lucky animal
/// </summary>
public class CreateLuckyAnimalsDto : IMapWith<CreateOrderCommand>
{
	/// <summary>
	/// Base64 encoded photo of lucky animal
	/// </summary>
	public string PhotoBase64 { get; init; } = null!;

	/// <summary>
	/// Comment
	/// </summary>
	public string? Comment { get; init; }

	/// <summary>
	/// Date of adoption
	/// </summary>
	public DateTime AdoptionDate { get; init; }

	/// <summary>
	/// Id of the animal
	/// </summary>
	public Guid AnimalId { get; init; }

	#region IMapWith<CreateOrderCommand> Members
	public void Mapping(Profile profile)
	{
		profile.CreateMap<CreateLuckyAnimalsDto, CreateOrderCommand>()
			.ForMember(d => d.PhotoUrl, o => o.Ignore());
	}
	#endregion

}