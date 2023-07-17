using AnimalShelter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalShelter.Persistence.EntityTypeConfigurations;

/// <summary>
/// Configuration for <see cref="Subscription" /> entity
/// </summary>
public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
{

	#region IEntityTypeConfiguration<Subscription> Members
	public void Configure(EntityTypeBuilder<Subscription> builder)
	{
		builder.HasKey(s => s.Id);
		builder.HasIndex(s => s.Id).IsUnique();
		builder.Property(s => s.Id).ValueGeneratedOnAdd();

		builder.Property(s => s.Email)
			.IsRequired()
			.HasMaxLength(256);
	}
	#endregion

}