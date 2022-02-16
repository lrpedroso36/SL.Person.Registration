﻿using SL.Person.Registration.Domain.PersonAggregate.Validations;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;

namespace SL.Person.Registration.Domain.PersonAggregate.Extensions
{
    public static class AddressExtensions
    {
        public static Result<bool> Validate<T>(this Address address)
        {
            var result = new Result<bool>();

            var validation = new AddressValidation()
                .Validate(address);

            if (!validation.IsValid)
            {
                validation.Errors.ForEach(error => result.AddErrors(error.ErrorMessage, ErrorType.EntitiesProperty));
            }

            return result;
        }
    }
}