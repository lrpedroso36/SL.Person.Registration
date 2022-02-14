using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using SL.Person.Registration.Domain.PersonAggregate.Validations;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;

namespace SL.Person.Registration.Domain.PersonAggregate.Extensions
{
    public static class PersonRegistrationExtensions
    {
        public static Result<T> ValidateInstanceByType<T>(this PersonRegistration person, PersonType personType)
        {
            var result = new Result<T>();

            var validation = new PersonRegistrationValidation(personType)
                .Validate(person);

            if (!validation.IsValid)
            {
                validation.Errors.ForEach(error => result.AddErrors(error.ErrorMessage, ErrorType.NotFoundData));
            }

            return result;
        }

        public static Result<T> ValidateInstance<T>(this PersonRegistration person)
        {
            var result = new Result<T>();

            var validation = new PersonRegistrationValidation()
                .Validate(person);

            if (!validation.IsValid)
            {
                validation.Errors.ForEach(error => result.AddErrors(error.ErrorMessage, ErrorType.NotFoundData));
            }

            return result;
        }
    }
}
