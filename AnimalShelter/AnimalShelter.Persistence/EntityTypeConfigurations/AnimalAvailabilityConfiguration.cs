using AnimalShelter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalShelter.Persistence.EntityTypeConfigurations;

/// <summary>
/// Configuration for <see cref="AnimalAvailability" /> entity
/// </summary>
public class AnimalAvailabilityConfiguration : IEntityTypeConfiguration<AnimalAvailability>
{

	#region IEntityTypeConfiguration<AnimalAvailability> Members
	public void Configure(EntityTypeBuilder<AnimalAvailability> builder)
	{
		builder.HasKey(aa => aa.Id);
		builder.HasIndex(aa => aa.Id).IsUnique();
		builder.Property(aa => aa.Id).ValueGeneratedOnAdd();

		builder.Property(aa => aa.Name)
			.IsRequired()
			.HasMaxLength(50);
	}
	#endregion

}