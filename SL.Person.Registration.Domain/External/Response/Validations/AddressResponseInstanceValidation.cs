using FluentValidation;
using FluentValidation.Results;

namespace SL.Person.Registration.Domain.External.Response.Validations;

public class AddressResponseInstanceValidation : AbstractValidator<AddressResponse>
{
    public override ValidationResult Validate(ValidationContext<AddressResponse> context)
    {
        return context?.InstanceToValidate == null
               ? new ValidationResult(new[] { new ValidationFailure("instance", "Endereço não encontrado.") })
               : base.Validate(context);
    }
}
