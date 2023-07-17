namespace AnimalShelter.Application.Requests.AnimalAvailabilities.Queries.GetAnimalAvailabilities;

/// <summary>
/// View model for <see cref="AnimalAvailabilityDto" /> model
/// </summary>
/// <param name="AnimalAvailabilities"></param>
public sealed record AnimalAvailabilitiesVm(IList<AnimalAvailabilityDto> AnimalAvailabilities);