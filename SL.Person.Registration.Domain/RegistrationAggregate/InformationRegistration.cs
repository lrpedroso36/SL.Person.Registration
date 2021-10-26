using System.Collections.Generic;
using System.Linq;
using SL.Person.Registration.Domain.InterViewAggregate;
using SL.Person.Registration.Domain.PersonAggregate;

namespace SL.Person.Registration.Domain.RegistrationAggregate
{
    public class InformationRegistration
    {
        public object _id { get; private set; }

        public PersonRegistration PersonRegistration { get; private set; }

        public List<Interview> Interviews { get; private set; }

        protected InformationRegistration()
        {

        }

        protected InformationRegistration(PersonRegistration personRegistration, List<Interview> interviews, object id = null)
        {
            PersonRegistration = personRegistration;
            SetInterviews(interviews);
            _id = id;
        }

        public static InformationRegistration CreateInstance(PersonRegistration personRegistration, List<Interview> interviews, object id = null)
            => new InformationRegistration(personRegistration, interviews, id);

        private void SetInterviews(List<Interview> interviews)
        {
            if (interviews != null && interviews.Any())
            {
                Interviews = new List<Interview>();
                Interviews = interviews;
            }
        }
    }
}
