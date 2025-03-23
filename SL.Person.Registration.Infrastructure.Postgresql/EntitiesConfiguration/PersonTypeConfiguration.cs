using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SL.Person.Registration.Domain.PersonAggregate;

namespace SL.Person.Registration.Infrastructure.Postgresql.EntitiesConfiguration;

public class PersonTypeConfiguration : IEntityTypeConfiguration<PersonType>
{
    public void Configure(EntityTypeBuilder<PersonType> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(p => p.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.ToTable("PersonTypes");

        builder.HasData(PersonType.All(),
            PersonType.Tarefeiro(),
            PersonType.Assistido(),
            PersonType.Palestrante(),
            PersonType.Entrevistador()
        );
    }
}
