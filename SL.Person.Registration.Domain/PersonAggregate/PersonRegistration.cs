using System;
using System.Collections.Generic;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;

namespace SL.Person.Registration.Domain.PersonAggregate
{
    public class PersonRegistration
    {
        public List<PersonType> Types { get; set; }

        public string Name { get; private set; }

        public DateTime BirthDate { get; private set; }

        public int YearsOld { get; private set; }

        public long DocumentNumber { get; private set; }

        public Address Address { get; private set; }

        public Contact Contact { get; private set; }

        public Authentication Authentication { get; private set; }

        protected PersonRegistration(List<PersonType> types,
            string name,
            DateTime birthDate,
            int yeasOld,
            long documentNumber,
            Address address,
            Contact contact,
            Authentication authentication)
        {
            Types = types;
            Name = name;
            BirthDate = birthDate;
            YearsOld = yeasOld;
            DocumentNumber = documentNumber;
            Address = SetAddress(address);
            Contact = SetContact(contact);
            Authentication = SetAuthentication(authentication);
        }

        public static PersonRegistration CreateInstance(List<PersonType> type,
            string name,
            DateTime birthDate,
            int yeasOld,
            long documentNumber,
            Address address,
            Contact contact,
            Authentication authentication)
        => new PersonRegistration(type, name, birthDate, yeasOld, documentNumber, address, contact, authentication);

        private Contact SetContact(Contact contact)
        {
            return contact ?? null;
        }

        private Address SetAddress(Address address)
        {
            return address ?? null;
        }

        private Authentication SetAuthentication(Authentication authentication)
        {
            return authentication ?? null;
        }
    }
}

