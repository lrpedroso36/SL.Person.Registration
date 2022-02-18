using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Validations;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;

namespace SL.Person.Registration.Application.Extensions
{
    public static class AddressExtensions
    {
        public static void Validate(this Address address)
        {
            var validation = new AddressValidation()
                .Validate(address);

            if (!validation.IsValid)
            {
                var result = new Result();
                validation.Errors.ForEach(error => result.AddErrors(error.ErrorMessage, ErrorType.EntitiesProperty));
                throw new HttpRequestException(result);
            }
        }
    }
}
