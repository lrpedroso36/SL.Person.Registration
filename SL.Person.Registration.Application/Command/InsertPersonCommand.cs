using System.Collections.Generic;
using MediatR;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;

namespace SL.Person.Registration.Application.Command
{
    public class InsertPersonCommand : IRequest<bool>
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
                State,
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
