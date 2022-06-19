using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using System;
using System.Collections.Generic;

namespace SL.Person.Registration.Domain.Requests
{
    public class PersonRequest
    {
        public List<PersonType> Types { get; set; } = new List<PersonType>();

        public string Name { get; set; }

        public GenderType Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public long DocumentNumber { get; set; }

        public PersonRegistration GetPersonRegistration()
        {
            var person = PersonRegistration.CreateInstance(Types,
                Name.ToUpper(),
                Gender,
                BirthDate,
                DocumentNumber);

            return person;
        }
    }
}
