using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SL.Person.Registration.Domain.PersonAggregate
{
    public class Interview
    {
        public TreatmentType TreatmentType { get; private set; }

        public WeakDayType WeakDayType { get; private set; }

        public InterviewType Type { get; private set; }

        public DateTime Date { get; private set; }

        public TratamentStatus Status { get; private set; }

        public PersonRegistration Interviewer { get; private set; }

        public int Amount { get; private set; }

        public string Opinion { get; private set; }

        public List<Tratament> Trataments { get; private set; }

        protected Interview()
        {

        }

        protected Interview(TreatmentType treatmentType, WeakDayType weakDayType, InterviewType type, DateTime date, PersonRegistration person, int amount, string opinion)
        {
            TreatmentType = treatmentType;
            WeakDayType = weakDayType;
            Type = type;
            Date = date;
            Interviewer = SetPerson(person);
            Amount = amount;
            Opinion = opinion;
            Status = TratamentStatus.InProcess;
            SetTrataments(weakDayType, amount);
        }

        public static Interview CreateInstance(TreatmentType treatmentType,
                                               WeakDayType weakDayType,
                                               InterviewType type,
                                               DateTime date,
                                               PersonRegistration person,
                                               int amount,
                                               string opinion)
        => new Interview(treatmentType, weakDayType, type, date, person, amount, opinion);

        private PersonRegistration SetPerson(PersonRegistration person)
        {
            if (person.Types.Contains(PersonType.Entrevistador))
            {
                return PersonRegistration.CreateInstance(person._id, person.Types, person.Name, person.DocumentNumber);
            }

            return null;
        }

        private void SetTrataments(WeakDayType weakDayType, int amount)
        {
            Trataments = new List<Tratament>();
            var count = 0;

            var dateTime = Date;

            while (count != amount)
            {
                dateTime = dateTime.AddDays(1);

                if ((int)dateTime.DayOfWeek == (int)weakDayType)
                {
                    Trataments.Add(Tratament.CreateInstance(dateTime, null));
                    count++;
                }
            }
        }

        public void SetPresenceTratament(DateTime date, PersonRegistration taskMaster)
        {
            Trataments.OrderBy(x => x.Date)
                      .FirstOrDefault(x => !x.Presence.HasValue)?.SetPresence(date, taskMaster);

            if (Trataments.All(x => x.Presence.HasValue && x.Presence.Value))
            {
                Status = TratamentStatus.Concluded;
            }
        }
    }
}
