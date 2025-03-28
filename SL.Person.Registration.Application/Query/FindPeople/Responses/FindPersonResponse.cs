﻿using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SL.Person.Registration.Application.Query.FindPeople.Responses;

public class FindPersonResponse
{
    public string Id { get; set; }

    public List<PersonType> Types { get; set; } = new List<PersonType>();

    public string Name { get; set; }

    public GenderType Gender { get; set; }

    public int YearsOld { get; set; }

    public string BirthDate { get; set; }

    public long DocumentNumber { get; set; }

    public string ZipCode { get; set; }

    public string Street { get; set; }

    public string Number { get; set; }

    public string Neighborhood { get; set; }

    public string Complement { get; set; }

    public string City { get; set; }

    public string State { get; set; }

    public int DDD { get; set; }

    public string PhoneNumber { get; set; }

    public List<FindInterviewResponse> Interviews { get; set; } = new List<FindInterviewResponse>();

    public List<FindAssignmentResponse> Assignments { get; set; } = new List<FindAssignmentResponse>();

    public bool EnabledLaborerPresence { get; set; }

    public bool TratamentInProcess { get; set; }

    public bool LaborerPresenceConfirmed { get; set; }

    public bool TratamentPresenceConfirmed { get; set; }

    public bool EnabledTratamentView { get; set; }

    public static explicit operator FindPersonResponse(PersonRegistration person)
    {
        var result = new FindPersonResponse();

        result.Id = person.Id.ToString();
        result.Types = [.. person.PersonRegistrationPersonTypes.Select(x => x.PersonType)];
        result.Name = person.Name;
        result.Gender = person.Gender;
        result.YearsOld = GetYearsOld(person.BithDate);
        result.BirthDate = GetBirthDate(person.BithDate);
        result.DocumentNumber = person.DocumentNumber;
        result.EnabledLaborerPresence = person.EnabledLaborerPresence();
        result.TratamentInProcess = person.TratamentInProcess();
        result.TratamentPresenceConfirmed = person.TratamentPresenceConfirmed();
        result.LaborerPresenceConfirmed = person.LaborerPresenceConfirmed();
        result.EnabledTratamentView = person.Interviews != null;

        if (person.Address != null)
        {
            result.ZipCode = person.Address.ZipCode;
            result.Street = person.Address.Street;
            result.Number = person.Address.Number;
            result.Neighborhood = person.Address.Neighborhood;
            result.Complement = person.Address.Complement;
            result.City = person.Address.City;
            result.State = person.Address.State;
        }

        if (person.Contact != null)
        {
            result.DDD = person.Contact.DDD;
            result.PhoneNumber = person.Contact.PhoneNumber;
        }

        if (person.Interviews != null && person.Interviews.Count > 0)
        {
            result.Interviews = person.Interviews.OrderByDescending(x => x.Date).Select(x => (FindInterviewResponse)x).ToList();
        }

        if (person.Assignments != null && person.Assignments.Count > 0)
        {
            result.Assignments = person.Assignments.Select(x => (FindAssignmentResponse)x).ToList();
        }

        return result;
    }

    private static string GetBirthDate(DateTime? bithDate)
    {
        return bithDate == null ? "0001-01-01" : bithDate.Value.ToString("yyyy-MM-dd");
    }

    private static int GetYearsOld(DateTime? bithDate)
    {
        return bithDate == null || bithDate == DateTime.MinValue ? 0 : DateTime.Now.Year - bithDate.Value.Year;
    }
}
