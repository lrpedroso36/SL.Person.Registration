using System;

namespace SL.Person.Registration.Domain.PersonAggregate
{
    public class Assignment
    {
        public DateTime Date { get; private set; }

        public bool Presence { get; private set; }

        protected Assignment(DateTime date, bool presence)
        {
            Date = date;
            Presence = presence;
        }

        public static Assignment CreateInstance(DateTime date, bool presence)
            => new Assignment(date, presence);
    }
}
