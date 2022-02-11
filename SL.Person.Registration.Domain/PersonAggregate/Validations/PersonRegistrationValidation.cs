using FluentValidation;
using FluentValidation.Results;
using SL.Person.Registratio.CrossCuting.Resources;

namespace SL.Person.Registration.Domain.PersonAggregate.Validations
{
    public class PersonRegistrationValidation : AbstractValidator<PersonRegistration>
    {
        public override ValidationResult Validate(ValidationContext<PersonRegistration> context)
        {
            return context?.InstanceToValidate == null
                ? new ValidationResult(new[] { new ValidationFailure("instance", ResourceMessagesValidation.PersonRegistration_InstanceInvalid) })
                : base.Validate(context);
        }
    }
}
