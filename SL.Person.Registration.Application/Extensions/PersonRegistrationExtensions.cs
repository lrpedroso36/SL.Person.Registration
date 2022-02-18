using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using SL.Person.Registration.Domain.PersonAggregate.Validations;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;

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
    }
}
