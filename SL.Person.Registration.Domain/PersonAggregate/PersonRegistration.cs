using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using System;
using System.Collections.Generic;

namespace SL.Person.Registration.Domain.PersonAggregate
{
    public class PersonRegistration
    {
        public Guid _id { get; private set; }

        public List<PersonType> Types { get; set; } = new List<PersonType>();

        public string Name { get; private set; }

        public GenderType Gender { get; private set; }

        public int YearsOld { get; private set; }

        public long DocumentNumber { get; private set; }

        public Address Address { get; private set; }

        public Contact Contact { get; private set; }

        protected PersonRegistration()
        {

        }

        protected PersonRegistration(List<PersonType> types,
            string name,
            GenderType gender,
            int yeasOld,
            long documentNumber,
            Address address,
            Contact contact)
        {
            Types = types;
            Name = name;
            Gender = gender;
            YearsOld = yeasOld;
            DocumentNumber = documentNumber;
            Address = SetAddress(address);
            Contact = SetContact(contact);
        }

        public static PersonRegistration CreateInstance(List<PersonType> type,
            string name,
            GenderType gender,
            int yeasOld,
            long documentNumber,
            Address address,
            Contact contact)
        => new PersonRegistration(type, name, gender, yeasOld, documentNumber, address, contact);

        public void SetId(Guid id)
        {
            _id = id;
        }

        private Contact SetContact(Contact contact)
        {
            return contact ?? null;
        }

        private Address SetAddress(Address address)
        {
            return address ?? null;
        }

        public void AddPersonType(PersonType personType)
        {
            if (Types == null)
            {
                Types = new List<PersonType>();
            }
            Types.Add(personType);
        }

        public void AddAdress(Address address)
        {
            Address = SetAddress(address);
        }
        public void AddContact(Contact contact)
        {
            Contact = SetContact(contact);
        }
    }
}

