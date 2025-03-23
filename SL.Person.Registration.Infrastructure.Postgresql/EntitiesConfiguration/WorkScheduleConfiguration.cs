using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SL.Person.Registration.Domain.PersonAggregate;

namespace SL.Person.Registration.Infrastructure.Postgresql.EntitiesConfiguration;

public class WorkScheduleConfiguration : IEntityTypeConfiguration<WorkSchedule>
{
    public void Configure(EntityTypeBuilder<WorkSchedule> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(p => p.WeakDayType)
           .HasMaxLength(20)
           .IsRequired();

        builder.Property(p => p.Date)
                .IsRequired();

        builder.Property(p => p.DoTheReading);

        builder.ToTable("WorkSchedules");
    }
}
