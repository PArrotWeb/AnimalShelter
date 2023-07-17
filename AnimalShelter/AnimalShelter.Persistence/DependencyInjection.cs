using AnimalShelter.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AnimalShelter.Persistence;

/// <summary>
/// Dependency injection for persistence layer
/// </summary>
public static class DependencyInjection
{
	/// <summary>
	/// Add persistence layer
	/// </summary>
	/// <param name="services"></param>
	/// <param name="configuration"></param>
	/// <returns></returns>
	public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
	{
		// Add database context
		var connectionString = configuration.GetConnectionString("SqliteConnection");
		services.AddDbContext<AnimalShelterDbContext>(options => options.UseSqlite(connectionString));
		services.AddScoped<IAnimalShelterDbContext>(provider => provider.GetService<AnimalShelterDbContext>()!);

		return services;
	}
}