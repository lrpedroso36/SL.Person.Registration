using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SL.Person.Registration.Domain.PersonAggregate;

namespace SL.Person.Registration.Infrastructure.Postgresql.EntitiesConfiguration;

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(p => p.DDD)
            .HasMaxLength(2)
            .IsRequired();

        builder.Property(p => p.PhoneNumber)
          .HasMaxLength(15)
          .IsRequired();

        builder.ToTable("Contacts");
    }
}
