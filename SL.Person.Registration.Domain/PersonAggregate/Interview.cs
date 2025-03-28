﻿using SL.Person.Registration.Domain.PersonAggregate.Base;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SL.Person.Registration.Domain.PersonAggregate;

public class Interview : Entity
{
    public TreatmentType TreatmentType { get; private set; }

    public WeakDayType WeakDayType { get; private set; }

    public InterviewType InterviewType { get; private set; }

    public DateTime Date { get; private set; }

    public TratamentStatus Status { get; private set; }

    public Guid InterviewerId { get; set; }
    public PersonRegistration Interviewer { get; private set; }

    public int Amount { get; private set; }

    public string Opinion { get; private set; }

    public List<Tratament> Trataments { get; private set; }

    public Guid PersonRegistrationId { get; set; }
    public PersonRegistration PersonRegistration { get; set; }

    protected Interview()
    {

    }

    protected Interview(TreatmentType treatmentType, WeakDayType weakDayType, InterviewType interviewType, DateTime date, PersonRegistration person, int amount, string opinion)
    {
        TreatmentType = treatmentType;
        WeakDayType = weakDayType;
        InterviewType = interviewType;
        Date = date;
        Interviewer = SetPerson(person);
        Amount = amount;
        Opinion = opinion;
        Status = TratamentStatus.InProcess;
        SetTrataments(weakDayType, amount);
    }

    public static Interview CreateInstance(TreatmentType treatmentType, WeakDayType weakDayType, InterviewType type,
                                           DateTime date,
                                           PersonRegistration person,
                                           int amount,
                                           string opinion)
    => new(treatmentType, weakDayType, type, date, person, amount, opinion);

    private PersonRegistration SetPerson(PersonRegistration person)
    {
        if (person.PersonRegistrationPersonTypes.Any(x => x.PersonType.Name == "Entrevistador"))
        {
            return PersonRegistration.CreateInstanceSimple(person.Id, [.. person.PersonRegistrationPersonTypes.Select(x => x.PersonType)], 
                person.Name, person.DocumentNumber);
        }

        return null;
    }

    private void SetTrataments(WeakDayType weakDayType, int amount)
    {
        Trataments = new List<Tratament>();

        var count = 0;
        var dateTime = Date;

        while (count != amount)
        {
            dateTime = dateTime.AddDays(1);

            if ((int)dateTime.DayOfWeek == (int)weakDayType)
            {
                Trataments.Add(Tratament.CreateInstance(dateTime));
                count++;
            }
        }
    }

    public void SetPresenceTratament(DateTime date)
    {
        Trataments.OrderBy(x => x.Date)
                  .FirstOrDefault(x => !x.Presence.HasValue)?.SetPresence(date);

        if (Trataments.All(x => x.Presence.HasValue && x.Presence.Value))
        {
            Status = TratamentStatus.Concluded;
        }
    }
}
