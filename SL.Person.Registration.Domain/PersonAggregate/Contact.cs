namespace SL.Person.Registration.Domain.PersonAggregate
{
    public class Contact
    {
        public int DDD { get; private set; }

        public long PhoneNumber { get; private set; }

        protected Contact(int ddd, long phoneNumber)
        {
            DDD = ddd;
            PhoneNumber = phoneNumber;
        }

        public static Contact CreateInstance(int ddd, long phoneNumber)
            => new Contact(ddd, phoneNumber);
    }
}
