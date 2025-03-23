using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SL.Person.Registration.Domain.PersonAggregate;

namespace SL.Person.Registration.Infrastructure.Postgresql.EntitiesConfiguration;

public class PersonRegistrationPersonTypeConfiguration : IEntityTypeConfiguration<PersonRegistrationPersonType>
{
    public void Configure(EntityTypeBuilder<PersonRegistrationPersonType> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(pr => pr.PersonType)
             .WithMany()
             .HasForeignKey(pr => pr.PersonTypeId)
             .IsRequired();

        builder.ToTable("PersonRegistrationPersonTypes");
    }
}
