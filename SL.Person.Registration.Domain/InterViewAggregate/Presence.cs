using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using System;
using System.Linq;

namespace SL.Person.Registration.Domain.InterViewAggregate
{
    public class Presence
    {
        public DateTime Date { get; private set; }

        public string TaskMaster { get; private set; }

        protected Presence()
        {

        }

        private Presence(DateTime date, PersonRegistration taskMaster)
        {
            Date = date;
            TaskMaster = SetTaskMaster(taskMaster);
        }

        private string SetTaskMaster(PersonRegistration taskMaster)
        {
            if (taskMaster != null && taskMaster.Types.Any(x => x == PersonType.Tarefeiro))
            {
                return taskMaster.Name;
            }

            return null;
        }

        public static Presence CreateInstance(DateTime date, PersonRegistration taskMaster)
            => new Presence(date, taskMaster);
    }
}
