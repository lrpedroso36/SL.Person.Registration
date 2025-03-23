using Microsoft.EntityFrameworkCore;
using SL.Person.Registration.Domain.PersonAggregate;

namespace SL.Person.Registration.Infrastructure.Postgresql.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<PersonRegistration> PersonRegistrations { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Assignment> Assignments { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Interview> Interviews { get; set; }
    public DbSet<Tratament> Trataments { get; set; }
    public DbSet<WorkSchedule> WorkSchedules { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
