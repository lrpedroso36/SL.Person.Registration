using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SL.Person.Registration.Domain.PersonAggregate;
using System.Reflection.Emit;

namespace SL.Person.Registration.Infrastructure.Postgresql.EntitiesConfiguration;

public class InterviewConfiguration : IEntityTypeConfiguration<Interview>
{
    public void Configure(EntityTypeBuilder<Interview> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(p => p.TreatmentType)
                .HasMaxLength(15)
                .IsRequired();

        builder.Property(p => p.WeakDayType)
              .HasMaxLength(15)
              .IsRequired();

        builder.Property(p => p.InterviewType)
              .HasMaxLength(15)
              .IsRequired();

        builder.Property(p => p.Date)
             .HasMaxLength(15)
             .IsRequired();

        builder.Property(p => p.Status)
            .HasMaxLength(15)
            .IsRequired();

        builder.Property(p => p.Amount)
           .IsRequired();

        builder.Property(p => p.Opinion)
            .HasMaxLength(10000)
            .IsRequired();

        builder.HasOne(i => i.Interviewer)
               .WithOne(p => p.Interviewer)  
               .HasForeignKey<Interview>(i => i.InterviewerId);

        builder.HasMany(i => i.Trataments)
               .WithOne(t => t.Interview)
               .HasForeignKey(t => t.InterviewId)
               .IsRequired();

        builder.ToTable("Interviews");
    }
}
