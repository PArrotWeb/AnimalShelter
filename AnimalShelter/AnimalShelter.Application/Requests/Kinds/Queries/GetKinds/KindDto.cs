using AnimalShelter.Application.Common.Mappings;
using AnimalShelter.Domain.Entities;
using AutoMapper;

namespace AnimalShelter.Application.Requests.Kinds.Queries.GetKinds;

/// <summary>
/// Represents data transfer object for <see cref="Kind" /> model
/// </summary>
public sealed class KindDto : IMapWith<Kind>
{
	/// <summary>
	/// Id of the kind
	/// </summary>
	public Guid Id { get; init; }

	/// <summary>
	/// Name of the kind
	/// </summary>
	public string Name { get; init; } = null!;

	#region IMapWith<Kind> Members
	public void Mapping(Profile profile)
	{
		profile.CreateMap<Kind, KindDto>();
	}
	#endregion

}