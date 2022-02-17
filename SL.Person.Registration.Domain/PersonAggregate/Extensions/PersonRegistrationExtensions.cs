using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using SL.Person.Registration.Domain.PersonAggregate.Validations;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;

namespace SL.Person.Registration.Domain.PersonAggregate.Extensions
{
    public static class PersonRegistrationExtensions
    {
        public static ResultBase ValidateInstanceByType(this PersonRegistration person, PersonType personType)
        {
            var result = new ResultEntities<PersonRegistration>();

            var validation = new PersonRegistrationInstanceValidation(personType)
                .Validate(person);

            if (!validation.IsValid)
            {
                validation.Errors.ForEach(error => result.AddErrors(error.ErrorMessage, ErrorType.NotFoundData));
            }

            return result;
        }

        public static ResultBase ValidateInstance(this PersonRegistration person)
        {
            var result = new ResultEntities<PersonRegistration>();

            var validation = new PersonRegistrationInstanceValidation()
                .Validate(person);

            if (!validation.IsValid)
            {
                validation.Errors.ForEach(error => result.AddErrors(error.ErrorMessage, ErrorType.NotFoundData));
            }

            return result;
        }

        public static ResultBase Validate(this PersonRegistration person)
        {
            var result = new Result();

            var validation = new PersonRegistrationValidation()
                .Validate(person);

            if (!validation.IsValid)
            {
                validation.Errors.ForEach(error => result.AddErrors(error.ErrorMessage, ErrorType.EntitiesProperty));
            }

            return result;
        }
    }
}
