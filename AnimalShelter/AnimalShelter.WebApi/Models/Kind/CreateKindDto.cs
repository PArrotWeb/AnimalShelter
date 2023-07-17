using AnimalShelter.Application.Common.Mappings;
using AnimalShelter.Application.Requests.Kinds.Commands.CreateKind;
using AutoMapper;

namespace AnimalShelter.WebApi.Models.Kind;

/// <summary>
/// DTO for creating a new kind
/// </summary>
public class CreateKindDto : IMapWith<CreateKindCommand>
{
	/// <summary>
	/// Name of the new kind
	/// </summary>
	public string Name { get; init; } = null!;

	#region IMapWith<CreateKindCommand> Members
	public void Mapping(Profile profile)
	{
		profile.CreateMap<CreateKindDto, CreateKindCommand>();
	}
	#endregion

}