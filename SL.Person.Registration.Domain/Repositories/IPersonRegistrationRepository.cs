﻿using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using System.Collections.Generic;

namespace SL.Person.Registration.Domain.Repositories
{
    public interface IPersonRegistrationRepository
    {
        void Insert(PersonRegistration registration);

        PersonRegistration GetByDocument(long documentNumber);

        PersonRegistration GetByContactNumber(int ddd, long phoneNumber);

        IEnumerable<PersonRegistration> GetByName(string name);

        bool Update(PersonRegistration registration);

        PersonRegistration GetByDocument(long documentNumber, PersonType personType);
    }
}
