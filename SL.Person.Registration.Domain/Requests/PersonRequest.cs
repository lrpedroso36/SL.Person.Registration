using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using System.Collections.Generic;

namespace SL.Person.Registration.Domain.Requests
{
    public class PersonRequest
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

        public PersonRegistration GetPersonRegistration()
        {
            var contct = Contact.CreateInstance(DDD,
                PhoneNumber);

            var address = Address.CreateInstance(ZipCode,
                Street,
                Number,
                Neighborhood,
                Complement,
                City,
                State);

            var person = PersonRegistration.CreateInstance(Types,
                Name,
                Gender,
                YearsOld,
                DocumentNumber,
                address,
                contct);

            return person;
        }
    }
}
