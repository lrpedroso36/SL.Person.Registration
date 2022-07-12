using FluentValidation;
using FluentValidation.Results;
using SL.Person.Registration.Domain.Resources;

namespace SL.Person.Registration.Domain.External.Response.Validations
{
    public class AddressResponseInstanceValidation : AbstractValidator<AddressResponse>
    {
        public override ValidationResult Validate(ValidationContext<AddressResponse> context)
        {
            return context?.InstanceToValidate == null
                   ? new ValidationResult(new[] { new ValidationFailure("instance", DomainMessages.FindAddressByZipCodeValidation_NotFound) })
                   : base.Validate(context);
        }
    }
}
