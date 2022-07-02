using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SL.Person.Registration.Domain.PersonAggregate
{
    public class PersonRegistration
    {
        public Guid _id { get; private set; }

        public List<PersonType> Types { get; set; } = new List<PersonType>();

        public string Name { get; private set; }

        public GenderType Gender { get; private set; }

        public DateTime? BithDate { get; private set; }

        public long DocumentNumber { get; private set; }

        public Address Address { get; private set; }

        public Contact Contact { get; private set; }

        public List<Interview> Interviews { get; private set; }

        public List<Assignment> Assignments { get; private set; }

        public bool IsExcluded { get; private set; } = false;

        protected PersonRegistration()
        {

        }

        protected PersonRegistration(Guid id, List<PersonType> types, string name, long documentNumber)
        {
            _id = id;
            Types = types;
            Name = name;
            DocumentNumber = documentNumber;
        }

        protected PersonRegistration(List<PersonType> types, string name, GenderType gender, DateTime? birthDate, long documentNumber)
        {
            Types = types;
            Name = name;
            Gender = gender;
            BithDate = birthDate;
            DocumentNumber = documentNumber;
        }

        protected PersonRegistration(Guid id, List<PersonType> types, string name, GenderType gender, DateTime? birthDate, long documentNumber)
            : this(types, name, gender, birthDate, documentNumber)
        {
            _id = id;
        }

        public static PersonRegistration CreateInstanceSimple(Guid id, List<PersonType> types, string name, long documentNumber)
            => new PersonRegistration(id, types, name, documentNumber);

        public static PersonRegistration CreateInstance(List<PersonType> type, string name, GenderType gender, DateTime? birthDate, long documentNumber)
        => new PersonRegistration(type, name, gender, birthDate, documentNumber);

        public static PersonRegistration CreateUpdateInstance(Guid id, List<PersonType> type, string name, GenderType gender, DateTime? birthDate, long documentNumber)
        => new PersonRegistration(id, type, name, gender, birthDate, documentNumber);

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

            if (!Types.Contains(personType))
                Types.Add(personType);
        }

        public void AddAdress(Address address)
        {
            if (address != null)
            {
                Address = SetAddress(address);
            }
        }

        public void AddContact(Contact contact)
        {
            if (contact != null)
            {
                Contact = SetContact(contact);
            }
        }

        public void AddInterview(Interview interview)
        {
            if (Interviews == null)
            {
                Interviews = new List<Interview>();
            }

            Interviews.Add(interview);
        }

        public void SetPresenceTratament(DateTime dateTime)
        {
            var tratament = Interviews?.FirstOrDefault(x => x.Status == TratamentStatus.InProcess);
            tratament?.SetPresenceTratament(dateTime);
        }

        public void SetPresenceAssignment(DateTime date, bool presence)
        {
            if (Assignments == null)
            {
                Assignments = new List<Assignment>();
            }

            Assignments.Add(Assignment.CreateInstance(date, presence));
        }

        public bool TratamentInProcess()
        {
            return Interviews != null && Interviews.Any(x => x.Status == TratamentStatus.InProcess);
        }

        public bool TratamentPresenceConfirmed()
        {
            return Interviews != null && Interviews.Any(x => x.Status == TratamentStatus.InProcess && x.Trataments.Where(y => y.Presence != null).Any(y =>  y.Presence.Value && y.Date.Date == DateTime.Now.Date));
        }

        public bool EnabledLaborerPresence()
        {
            return Types != null && Types.Any(x => x == PersonType.Tarefeiro);
        }

        public bool LaborerPresenceConfirmed()
        {
            return Assignments != null && Assignments.Any(x => x.Presence && x.Date.Date == DateTime.Now.Date);
        }

        public void SetIsExcluded()
        {
            IsExcluded = true;
        }
    }
}

