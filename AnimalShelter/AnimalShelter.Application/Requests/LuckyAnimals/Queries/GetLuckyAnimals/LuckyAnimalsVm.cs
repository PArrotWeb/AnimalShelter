namespace AnimalShelter.Application.Requests.LuckyAnimals.Queries.GetLuckyAnimals;

/// <summary>
/// View model for <see cref="GetLuckyAnimalsQuery" />
/// </summary>
/// <param name="LuckyAnimals"></param>
public sealed record LuckyAnimalsVm(IList<LuckyAnimalDto> LuckyAnimals);