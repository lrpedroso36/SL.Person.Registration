using System;

namespace SL.Person.Registration.Domain.PersonAggregate
{
    public class Tratament
    {
        public DateTime Date { get; private set; }

        public bool? Presence { get; private set; }

        protected Tratament()
        {

        }

        private Tratament(DateTime date)
        {
            Date = date;
        }

        private Tratament(DateTime date, bool presence) : this(date)
        {
            Presence = presence;
        }

        public static Tratament CreateInstance(DateTime date)
            => new Tratament(date);

        public static Tratament CreateInstance(DateTime date, bool presence)
            => new Tratament(date, presence);

        public void SetPresence(DateTime date)
        {
            Date = date;
            Presence = true;
        }
    }
}
