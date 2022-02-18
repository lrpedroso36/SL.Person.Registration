using SL.Person.Registration.Domain.PersonAggregate;

namespace SL.Person.Registration.Domain.Requests
{
    public class ContactRequest
    {
        public int DDD { get; set; }

        public long PhoneNumber { get; set; }

        public Contact GetContact()
        {
            return Contact.CreateInstance(DDD, PhoneNumber);
        }
    }
}