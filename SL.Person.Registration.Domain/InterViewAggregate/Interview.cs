using System;
using SL.Person.Registration.Domain.InterViewAggregate.Enuns;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;

namespace SL.Person.Registration.Domain.InterViewAggregate
{
    public class Interview
    {
        public TreatmentType TreatmentType { get; private set; }

        public InterviewType Type { get; private set; }

        public DateTime Date { get; private set; }

        public PersonRegistration Person { get; private set; }

        public string Opinion { get; private set; }

        protected Interview(TreatmentType treatmentType, InterviewType type, DateTime date, PersonRegistration person, string opinion)
        {
            TreatmentType = treatmentType;
            Type = type;
            Date = date;
            Person = SetPerson(person);
            Opinion = opinion;
        }

        public static Interview CreateInstance(TreatmentType treatmentType, InterviewType type, DateTime date, PersonRegistration person, string opinion)
            => new Interview(treatmentType, type, date, person, opinion);

        private PersonRegistration SetPerson(PersonRegistration person)
        {
            if (person.Types.Contains(PersonType.Entrevistador))
            {
                return person;
            }

            return null;
        }
    }
}
