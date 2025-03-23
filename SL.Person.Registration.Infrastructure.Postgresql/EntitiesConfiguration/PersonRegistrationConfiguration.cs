using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SL.Person.Registration.Domain.PersonAggregate;

namespace SL.Person.Registration.Infrastructure.Postgresql.EntitiesConfiguration;

public class PersonRegistrationConfiguration : IEntityTypeConfiguration<PersonRegistration>
{
    public void Configure(EntityTypeBuilder<PersonRegistration> builder)
    {
        builder.Property(p => p.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(p => p.Gender)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(p => p.BithDate)
           .HasMaxLength(20)
           .IsRequired();

        builder.Property(p => p.DocumentNumber)
          .IsRequired();

        builder.HasMany(pr => pr.PersonRegistrationPersonTypes)
               .WithOne(i => i.PersonRegistration)
               .HasForeignKey(i => i.PersonRegistrationId);

        builder.HasOne(pr => pr.Address)
            .WithMany()
            .HasForeignKey(pr => pr.AddressId);

        builder.HasOne(pr => pr.Contact)
            .WithMany()
            .HasForeignKey(pr => pr.ContactId)
            .IsRequired();

        builder.HasMany(pr => pr.Interviews)
            .WithOne(i => i.PersonRegistration)
            .HasForeignKey(i => i.PersonRegistrationId);

        builder.HasMany(pr => pr.Assignments)
            .WithOne(a => a.PersonRegistration)
            .HasForeignKey(a => a.PersonRegistrationId);

        builder.HasMany(pr => pr.WorkSchedules)
            .WithOne(ws => ws.PersonRegistration)
            .HasForeignKey(ws => ws.PersonRegistrationId);

    }
}
