using System.Reflection;
using AnimalShelter.Application;
using AnimalShelter.Application.Common.Mappings;
using AnimalShelter.Application.Interfaces;
using AnimalShelter.Persistence;
using AnimalShelter.WebApi.Middleware.CustomExceptionMiddleware;
using AnimalShelter.WebApi.Services.Upload;

var builder = WebApplication.CreateBuilder(args);
ConfigureServices();

var app = builder.Build();
ConfigureApp();
app.Run();

void ConfigureServices()
{
	// Add services to the container
	builder.Services.AddPersistence(builder.Configuration);
	builder.Services.AddApplication();

	// Add custom exception handler
	builder.Services.AddEndpointsApiExplorer();

	// Add UploadService
	builder.Services.AddScoped<IUploadService, UploadService>();

	// Add controllers
	builder.Services.AddControllers();

	// Add swagger
	if (builder.Environment.IsDevelopment())
	{
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();
	}

	// Add mapping
	builder.Services.AddAutoMapper(config =>
	{
		config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
		config.AddProfile(new AssemblyMappingProfile(typeof(IAnimalShelterDbContext).Assembly));
	});

	// Add CORS
	builder.Services.AddCors(options =>
	{
		options.AddPolicy("AllowAll", policy =>
		{
			policy.AllowAnyHeader();
			policy.AllowAnyMethod();
			policy.AllowAnyOrigin();
		});
	});
}

void ConfigureApp()
{
	// Configure the HTTP request pipeline
	if (app.Environment.IsDevelopment())
	{
		app.UseSwagger();
		app.UseSwaggerUI();
	}

	// Initialize database
	using (var scope = app.Services.CreateScope())
	{
		var context = scope.ServiceProvider.GetRequiredService<AnimalShelterDbContext>();
		DbInitializer.Initialize(context);
	}

	// Middleware pipeline
	app.UseCustomExceptionHandler();
	app.UseStaticFiles();
	app.UseRouting();
	app.UseCors("AllowAll");
	app.MapControllers();
}