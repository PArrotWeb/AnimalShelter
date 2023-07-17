namespace AnimalShelter.Application.Requests.Kinds.Queries.GetKinds;

/// <summary>
/// View model for <see cref="GetKindsQuery" />
/// </summary>
/// <param name="Kinds"></param>
public sealed record KindsVm(IList<KindDto> Kinds);