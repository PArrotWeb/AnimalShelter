using MediatR;

namespace AnimalShelter.Application.Requests.Animals.Queries.GetAnimals;

/// <summary>
/// Query for getting all animals
/// </summary>
public sealed record GetAnimalsQuery : IRequest<AnimalsVm>;