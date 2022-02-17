using SL.Person.Registration.Domain.PersonAggregate.Validations;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;

namespace SL.Person.Registration.Domain.PersonAggregate.Extensions
{
    public static class ContactExtensions
    {
        public static ResultBase Validate(this Contact contact)
        {
            var result = new Result();

            var validation = new ContactValidation()
                .Validate(contact);

            if (!validation.IsValid)
            {
                validation.Errors.ForEach(error => result.AddErrors(error.ErrorMessage, ErrorType.EntitiesProperty));
            }

            return result;
        }
    }
}
