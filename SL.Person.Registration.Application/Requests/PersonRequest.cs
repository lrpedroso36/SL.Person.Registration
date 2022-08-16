using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using System;
using System.Collections.Generic;

namespace SL.Person.Registration.Application.Requests
{
    public class PersonRequest
    {
        public List<PersonType> Types { get; set; } = new List<PersonType>();

        public string Name { get; set; }

        public GenderType Gender { get; set; }

        public DateTime? BirthDate { get; set; }

        public long DocumentNumber { get; set; }

        public int DDD { get; set; }

        public long PhoneNumber { get; set; }

        public string ZipCode { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }

        public string Neighborhood { get; set; }

        public string Complement { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public PersonRegistration GetPersonRegistration()
        {
            var person = PersonRegistration.CreateInstance(Types,
                Name.ToUpper(),
                Gender,
                BirthDate,
                DocumentNumber);

            if (CheckInformationContact())
            {
                person.AddContact(Contact.CreateInstance(DDD, PhoneNumber));
            }

            if (CheckInformationAddress())
            {
                person.AddAdress(Address.CreateInstance(ZipCode, 
                                                        Street.ToUpper(), 
                                                        Number.ToUpper(), 
                                                        Neighborhood.ToUpper(), 
                                                        Complement.ToUpper(), 
                                                        City.ToUpper(), 
                                                        State.ToUpper()));
            }

            return person;
        }

        private bool CheckInformationContact()
        {
            return DDD != 0 || PhoneNumber != 0;
        }

        private bool CheckInformationAddress()
        {
            return !string.IsNullOrWhiteSpace(ZipCode) ||
                   !string.IsNullOrWhiteSpace(Street) ||
                   !string.IsNullOrWhiteSpace(Number) ||
                   !string.IsNullOrWhiteSpace(Neighborhood) ||
                   !string.IsNullOrWhiteSpace(City) ||
                   !string.IsNullOrWhiteSpace(State) ||
                   !string.IsNullOrWhiteSpace(Complement);
        }
    }
}
