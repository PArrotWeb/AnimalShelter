namespace AnimalShelter.Persistence;

public static class DbInitializer
{
	/// <summary>
	/// Initialize the database
	/// </summary>
	/// <param name="context"></param>
	public static void Initialize(AnimalShelterDbContext context)
	{
		// Create the database if it doesn't exist
		context.Database.EnsureCreated();
	}
}