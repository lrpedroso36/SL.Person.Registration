using FluentValidation;
using FluentValidation.Results;

namespace SL.Person.Registration.Domain.PersonAggregate.Validations;

public class PersonRegistrationInstanceValidation : AbstractValidator<PersonRegistration>
{
    private readonly string instanceInvalidTypeMessage;

    public PersonRegistrationInstanceValidation()
    {
        instanceInvalidTypeMessage = "Pessoa não encontrada.";
    }

    public override ValidationResult Validate(ValidationContext<PersonRegistration> context)
    {
        return context?.InstanceToValidate == null
            ? new ValidationResult(new[] { new ValidationFailure("instance", instanceInvalidTypeMessage) })
            : base.Validate(context);
    }
}
