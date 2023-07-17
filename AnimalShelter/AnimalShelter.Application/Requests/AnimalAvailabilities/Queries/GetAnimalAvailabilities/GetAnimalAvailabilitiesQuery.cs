using MediatR;

namespace AnimalShelter.Application.Requests.AnimalAvailabilities.Queries.GetAnimalAvailabilities;

/// <summary>
/// Query to get all animal availabilities
/// </summary>
public sealed record GetAnimalAvailabilitiesQuery : IRequest<AnimalAvailabilitiesVm>;