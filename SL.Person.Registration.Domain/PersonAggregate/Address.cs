﻿using SL.Person.Registration.Domain.PersonAggregate.Base;
using System;

namespace SL.Person.Registration.Domain.PersonAggregate;

public class Address : Entity
{
    public string ZipCode { get; private set; }

    public string Street { get; private set; }

    public string Number { get; private set; }

    public string Neighborhood { get; private set; }

    public string Complement { get; private set; }

    public string City { get; private set; }

    public string State { get; set; }

    public Guid PersonRegistrationId { get; set; }
    public PersonRegistration PersonRegistration { get; set; }

    protected Address()
    {

    }

    protected Address(string zipCode, string street, string number, string neighborhood, string complement, string city, string state)
    {
        ZipCode = zipCode;
        Street = street;
        Number = number;
        Neighborhood = neighborhood;
        Complement = complement;
        City = city;
        State = state;
    }

    public static Address CreateInstance(string zipCode, string street, string number, string neighborhood, string complement, string city, string state)
        => new Address(zipCode, street, number, neighborhood, complement, city, state);
}
