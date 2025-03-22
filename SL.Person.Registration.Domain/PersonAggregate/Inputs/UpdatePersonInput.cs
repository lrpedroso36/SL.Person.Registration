using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using System;
using System.Collections.Generic;

namespace SL.Person.Registration.Domain.PersonAggregate.Inputs;

public class UpdatePersonInput
{
    public Guid Id { get; set; }
    public List<PersonType> Type { get; set; }
    public string Name { get; set; }
    public GenderType Gender { get; set; }
    public DateTime? BirthDate { get; set; }
    public long DocumentNumber { get; set; }
    public List<Interview> Interviews { get; set; }
    public List<Assignment> Assignments { get; set; }
    public List<WorkSchedule> WorkSchedules { get; set; }
}
