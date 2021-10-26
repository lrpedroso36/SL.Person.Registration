using System;
using System.Collections.Generic;
using System.Linq;
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

        public string InterviewName { get; private set; }

        public int Amount { get; private set; }

        public string Opinion { get; private set; }

        public List<Presence> Presences { get; private set; }

        protected Interview()
        {

        }

        protected Interview(TreatmentType treatmentType, InterviewType type, DateTime date, PersonRegistration person, int amount, string opinion, List<Presence> presences)
        {
            TreatmentType = treatmentType;
            Type = type;
            Date = date;
            InterviewName = SetPerson(person);
            Amount = amount;
            Opinion = opinion;
            SetPrecences(presences);
        }

        public static Interview CreateInstance(TreatmentType treatmentType,
                                               InterviewType type,
                                               DateTime date,
                                               PersonRegistration person,
                                               int amount,
                                               string opinion,
                                               List<Presence> presences)
        => new Interview(treatmentType, type, date, person, amount, opinion, presences);

        private string SetPerson(PersonRegistration person)
        {
            if (person.Types.Contains(PersonType.Entrevistador))
            {
                return person.Name;
            }

            return null;
        }

        private void SetPrecences(List<Presence> presences)
        {
            if (presences != null && presences.Any())
            {
                Presences = new List<Presence>();
                Presences = presences;
            }
        }
    }

}
