using MediatR;

namespace AnimalShelter.Application.Requests.LuckyAnimals.Queries.GetLuckyAnimals;

/// <summary>
/// Query for getting all lucky animals
/// </summary>
public sealed record GetLuckyAnimalsQuery : IRequest<LuckyAnimalsVm>;