namespace AnimalShelter.Application.Requests.Animals.Queries.GetAnimals;

/// <summary>
/// Viewmodel for getting all animals
/// </summary>
/// <param name="Animals"></param>
public sealed record AnimalsVm(IList<AnimalDto> Animals);