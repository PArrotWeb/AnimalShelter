using AnimalShelter.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Application.Interfaces;

/// <summary>
/// Represents the database context of the application
/// </summary>
public interface IAnimalShelterDbContext
{
	/// <summary>
	/// Represents the animals table
	/// </summary>
	DbSet<Animal> Animals { get; set; }

	/// <summary>
	/// Represents the animal availabilities table
	/// </summary>
	DbSet<AnimalAvailability> AnimalAvailabilities { get; set; }

	/// <summary>
	/// Represents the events table
	/// </summary>
	DbSet<Event> Events { get; set; }

	/// <summary>
	/// Represents the kinds table
	/// </summary>
	DbSet<Kind> Kinds { get; set; }

	/// <summary>
	/// Represents the lucky animals table
	/// </summary>
	DbSet<LuckyAnimal> LuckyAnimals { get; set; }

	/// <summary>
	/// Represents the orders table
	/// </summary>
	DbSet<Order> Orders { get; set; }

	/// <summary>
	/// Represents the subscriptions table
	/// </summary>
	DbSet<Subscription> Subscriptions { get; set; }

	/// <summary>
	/// Saves the changes made to the database
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}