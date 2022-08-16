using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using System;

namespace SL.Person.Registration.Domain.PersonAggregate
{
    public class WorkSchedule
    {
        public WeakDayType WeakDayType { get; private set; }
        public DateTime Date { get; private set; }
        public bool DoTheReading { get; private set; }

        protected WorkSchedule() { }

        protected WorkSchedule(WeakDayType weakDayType, DateTime date, bool doTheReading)
        {
            WeakDayType = weakDayType;
            Date = date;
            DoTheReading = doTheReading;
        }

        public static WorkSchedule CreateInstance(WeakDayType weakDayType, DateTime date, bool doTheReading)
            => new WorkSchedule(weakDayType, date, doTheReading);
    }
}
