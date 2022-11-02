using FluentValidation;

namespace SL.Person.Registration.Domain.PersonAggregate.Validations;

public class PersonRegistrationValidation : AbstractValidator<PersonRegistration>
{
    public PersonRegistrationValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Informe o Nome da pessoa.")
            .NotNull()
            .WithMessage("Informe o Nome da pessoa");

        RuleFor(x => x.DocumentNumber)
            .NotEqual(0)
            .WithMessage("Informe o Número do documento da pessoa.");

        When(x => x.Address != null, () =>
        {
            RuleFor(a => a.Address).SetValidator(new AddressValidation());
        });

        When(x => x.Contact != null, () =>
        {
            RuleFor(c => c.Contact).SetValidator(new ContactValidation());
        });
    }
}
