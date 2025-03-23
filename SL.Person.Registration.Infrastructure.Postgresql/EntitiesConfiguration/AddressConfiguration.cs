using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SL.Person.Registration.Domain.PersonAggregate;

namespace SL.Person.Registration.Infrastructure.Postgresql.EntitiesConfiguration;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(p => p.ZipCode)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(p => p.Street)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(p => p.Number)
            .HasMaxLength(15);

        builder.Property(p => p.Neighborhood)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(p => p.Complement)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(p => p.City)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.State)
            .HasMaxLength(15)
            .IsRequired();

        builder.ToTable("Addresses");
    }
}
