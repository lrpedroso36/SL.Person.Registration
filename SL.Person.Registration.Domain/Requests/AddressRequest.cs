﻿using SL.Person.Registration.Domain.PersonAggregate;

namespace SL.Person.Registration.Domain.Requests
{
    public class AddressRequest
    {
        public long ZipCode { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }

        public string Neighborhood { get; set; }

        public string Complement { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public Address GetAddress()
        {
            return Address.CreateInstance(ZipCode, Street, Number, Neighborhood,Complement, City, State);
        }
    }
}
