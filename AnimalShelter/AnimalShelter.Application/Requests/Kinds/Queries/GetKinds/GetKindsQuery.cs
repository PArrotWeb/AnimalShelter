using MediatR;

namespace AnimalShelter.Application.Requests.Kinds.Queries.GetKinds;

/// <summary>
/// Query for getting all kinds
/// </summary>
public sealed record GetKindsQuery : IRequest<KindsVm>;