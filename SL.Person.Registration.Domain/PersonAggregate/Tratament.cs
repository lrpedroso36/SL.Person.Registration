using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using System;
using System.Linq;

namespace SL.Person.Registration.Domain.PersonAggregate
{
    public class Tratament
    {
        public DateTime Date { get; private set; }

        public PersonRegistration Laborer { get; private set; }

        public bool? Presence { get; private set; }

        protected Tratament()
        {

        }

        private Tratament(DateTime date, PersonRegistration laborer)
        {
            Date = date;
            Laborer = SetLaborer(laborer);
        }

        private Tratament(DateTime date, PersonRegistration laborer, bool presence) : this(date, laborer)
        {
            Presence = presence;
        }

        private PersonRegistration SetLaborer(PersonRegistration laborer)
        {
            if (laborer != null && laborer.Types.Any(x => x == PersonType.Tarefeiro))
            {
                return PersonRegistration.CreateInstance(laborer._id, laborer.Types, laborer.Name, laborer.DocumentNumber);
            }

            return null;
        }

        public static Tratament CreateInstance(DateTime date, PersonRegistration laborer)
            => new Tratament(date, laborer);

        public static Tratament CreateInstance(DateTime date, PersonRegistration laborer, bool presence)
            => new Tratament(date, laborer, presence);

        public void SetPresence(DateTime date, PersonRegistration laborer)
        {
            Date = date;
            Laborer = SetLaborer(laborer);
            Presence = true;
        }
    }
}
