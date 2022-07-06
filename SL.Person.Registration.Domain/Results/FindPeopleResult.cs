using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using System.Collections.Generic;

namespace SL.Person.Registration.Domain.Results
{
    public class FindPeopleResult
    {
        public List<PersonType> Types { get; set; } = new List<PersonType>();

        public string Name { get; set; }

        public long DocumentNumber { get; set; }

        public bool EnabledLaborerPresence { get; set; }

        public bool TratamentInProcess { get; set; }

        public bool LaborerPresenceConfirmed { get; set; }

        public bool TratamentPresenceConfirmed { get; set; }

        public bool EnabledTratamentView { get; set; }

        public static explicit operator FindPeopleResult(PersonRegistration person)
        {
            var result = new FindPeopleResult();

            result.Types = person.Types;
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
}
