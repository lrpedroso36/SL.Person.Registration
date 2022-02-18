using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Validations;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;

namespace SL.Person.Registration.Application.Extensions
{
    public static class ContactExtensions
    {
        public static void Validate(this Contact contact)
        {
            var validation = new ContactValidation()
                .Validate(contact);

            if (!validation.IsValid)
            {
                var result = new Result();
                validation.Errors.ForEach(error => result.AddErrors(error.ErrorMessage, ErrorType.EntitiesProperty));
                throw new ApplicationRequestException(result);
            }
        }
    }
}
