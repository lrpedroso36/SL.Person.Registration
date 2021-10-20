namespace SL.Person.Registration.Domain.PersonAggregate
{
    public class Address
    {
        public long ZipCode { get; private set; }

        public string Street { get; private set; }

        public string Number { get; private set; }

        public string Neighborhood { get; private set; }

        public string Complement { get; private set; }

        public string City { get; private set; }

        public string State { get; set; }

        protected Address(long zipCode, string street, string number, string neighborhood, string complement, string city, string state)
        {
            ZipCode = zipCode;
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            Complement = complement;
            City = city;
            State = state;
        }

        public static Address CreateInstance(long zipCode, string street, string number, string neighborhood, string complement, string city, string state)
            => new Address(zipCode, street, number, neighborhood, complement, city, state);
    }
}
