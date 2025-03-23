using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SL.Person.Registration.Domain.PersonAggregate;

namespace SL.Person.Registration.Infrastructure.Postgresql.EntitiesConfiguration;

public class TratamentConfiguration : IEntityTypeConfiguration<Tratament>
{
    public void Configure(EntityTypeBuilder<Tratament> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(p => p.Date)
           .IsRequired();

        builder.Property(p => p.Presence);

        builder.ToTable("Trataments");
    }
}
