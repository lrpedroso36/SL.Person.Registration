using SL.Person.Registration.Domain.PersonAggregate;
using System.Collections.Generic;
using System.Linq;

namespace SL.Person.Registration.Application.Query.FindPersonById.Responses;

public class FindPeopleResponse
{
    public string Id { get; set; }

    public List<PersonType> Types { get; set; } = new List<PersonType>();

    public string Name { get; set; }

    public long DocumentNumber { get; set; }

    public bool EnabledLaborerPresence { get; set; }

    public bool TratamentInProcess { get; set; }

    public bool LaborerPresenceConfirmed { get; set; }

    public bool TratamentPresenceConfirmed { get; set; }

    public bool EnabledTratamentView { get; set; }

    public static explicit operator FindPeopleResponse(PersonRegistration person)
    {
        var result = new FindPeopleResponse();

        result.Id = person.Id.ToString();
        result.Types = [.. person.PersonRegistrationPersonTypes.Select(x => x.PersonType)];
        result.Name = person.Name;
        result.DocumentNumber = person.DocumentNumber;
        result.EnabledLaborerPresence = person.EnabledLaborerPresence();
        result.TratamentInProcess = person.TratamentInProcess();
        result.TratamentPresenceConfirmed = person.TratamentPresenceConfirmed();
        result.LaborerPresenceConfirmed = person.LaborerPresenceConfirmed();
        result.EnabledTratamentView = person.Interviews != null;

        return result;
    }
}
