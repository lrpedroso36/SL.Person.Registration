using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Application.Results;
using SL.Person.Registration.Application.Results.Enums;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using SL.Person.Registration.Domain.PersonAggregate.Validations;
using System.Collections.Generic;
using System.Linq;

namespace SL.Person.Registration.Application.Extensions
{
    public static class PersonRegistrationExtensions
    {
        public static void ValidateInstanceByType(this PersonRegistration person, PersonType personType)
        {
            var validation = new PersonRegistrationInstanceValidation(personType)
                .Validate(person);

            if (!validation.IsValid)
            {
                var result = new ResultEntities<PersonRegistration>();
                result.SetErrorType(ErrorType.NotFoundData);
                validation.Errors.ForEach(error => result.AddErrors(error.ErrorMessage));
                throw new ApplicationRequestException(result);
            }
        }

        public static void ValidateInstance(this PersonRegistration person)
        {
            var validation = new PersonRegistrationInstanceValidation()
                .Validate(person);

            if (!validation.IsValid)
            {
                var result = new ResultEntities<PersonRegistration>();
                result.SetErrorType(ErrorType.NotFoundData);
                validation.Errors.ForEach(error => result.AddErrors(error.ErrorMessage));
                throw new ApplicationRequestException(result);
            }
        }

        public static void Validate(this PersonRegistration person)
        {
            var validation = new PersonRegistrationValidation()
                .Validate(person);

            if (!validation.IsValid)
            {
                var result = new Result();
                result.SetErrorType(ErrorType.EntitiesProperty);
                validation.Errors.ForEach(error => result.AddErrors(error.ErrorMessage));
                throw new DomainException(result);
            }
        }

        public static void ValidateList(this IEnumerable<PersonRegistration> persons)
        {
            if (persons == null || !persons.Any())
            {
                var result = new Result();
                result.SetErrorType(ErrorType.NotFoundData);
                result.AddErrors(ResourceMessagesValidation.FindPeopleQueryValidation_NotFound);
                throw new ApplicationRequestException(result);
            }
        }

        public static void ValidateFoundInstance(this PersonRegistration person)
        {
            if (person != null)
            {
                var result = new Result();
                result.SetErrorType(ErrorType.Found);
                result.AddErrors(ResourceMessagesValidation.InsertPersonCommandHandler_Found);
                throw new ApplicationRequestException(result);
            }
        }
    }
}
