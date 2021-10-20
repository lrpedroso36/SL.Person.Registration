using System;
using System.Collections.Generic;
using System.Linq;
using SL.Person.Registration.Domain.DonationAggregate;
using SL.Person.Registration.Domain.InterViewAggregate;
using SL.Person.Registration.Domain.PersonAggregate;

namespace SL.Person.Registration.Domain.RegistrationAggregate
{
    public class InformationRegistration
    {
        public PersonRegistration PersonRegistration { get; private set; }

        public List<Interview> Interviews { get; private set; }

        public List<Donation> Donations { get; private set; }

        protected InformationRegistration(PersonRegistration personRegistration, List<Interview> interviews,
            List<Donation> donations)
        {
            PersonRegistration = personRegistration;
            SetInterviews(interviews);
            SetDonations(donations);
        }

        public static InformationRegistration CreateInstance(PersonRegistration personRegistration, List<Interview> interviews,
            List<Donation> donations)
            => new InformationRegistration(personRegistration, interviews, donations);

        private void SetInterviews(List<Interview> interviews)
        {
            if (interviews != null && interviews.Any())
            {
                Interviews = new List<Interview>();
                Interviews = interviews;
            }
        }

        private void SetDonations(List<Donation> donations)
        {
            if (donations != null && donations.Any())
            {
                Donations = new List<Donation>();
                Donations = donations;
            }
        }
    }
}
