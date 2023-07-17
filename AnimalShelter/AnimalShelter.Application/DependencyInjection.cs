using System.Reflection;
using AnimalShelter.Application.Common.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace AnimalShelter.Application;

/// <summary>
/// Dependency injection for application layer
/// </summary>
public static class DependencyInjection
{
	/// <summary>
	/// Add application layer dependencies
	/// </summary>
	/// <param name="services"></param>
	/// <returns></returns>
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		// add mediatr
		services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

		// add fluent validation
		services.AddValidatorsFromAssemblies(new[] {Assembly.GetExecutingAssembly()});
		services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

		return services;
	}
}