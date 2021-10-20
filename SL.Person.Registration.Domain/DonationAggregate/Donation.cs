using System;
using SL.Person.Registration.Domain.DonationAggregate.Enuns;

namespace SL.Person.Registration.Domain.DonationAggregate
{
    public class Donation
    {
        public DonationType Type { get; private set; }

        public ReceiveType Receive { get; private set; }

        public DateTime Date { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        protected Donation()
        {

        }

        protected Donation(DonationType type, ReceiveType receive, DateTime date, string name, string description)
        {
            Type = type;
            Receive = receive;
            Date = date;
            Name = name;
            Description = description;
        }

        public static Donation CreateInstance(DonationType type, ReceiveType receive, DateTime date, string name, string description)
            => new Donation(type, receive, date, name, description);
    }
}
