using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using System.Collections.Generic;

namespace SL.Person.Registration.Domain.Results
{
    public class FindPersonResult
    {
        public List<PersonType> Types { get; set; } = new List<PersonType>();

        public string Name { get; set; }

        public GenderType Gender { get; set; }

        public int YearsOld { get; set; }

        public long DocumentNumber { get; set; }

        public long ZipCode { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }

        public string Neighborhood { get; set; }

        public string Complement { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int DDD { get; set; }

        public long PhoneNumber { get; set; }

        public static explicit operator FindPersonResult(PersonRegistration person)
        {
            var result = new FindPersonResult();

            result.Types = person.Types;
            result.Name = person.Name;
            result.Gender = person.Gender;
            result.YearsOld = person.YearsOld;
            result.DocumentNumber = person.DocumentNumber;
            result.ZipCode = person.Address.ZipCode;
            result.Street = person.Address.Street;
            result.Number = person.Address.Number;
            result.Neighborhood = person.Address.Neighborhood;
            result.Complement = person.Address.Complement;
            result.City = person.Address.City;
            result.State = person.Address.State;
            result.DDD = person.Contact.DDD;
            result.PhoneNumber = person.Contact.PhoneNumber;

            return result;
        }
    }
}
