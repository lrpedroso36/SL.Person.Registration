using FluentValidation;

namespace SL.Person.Registration.Domain.PersonAggregate.Validations;

public class ContactValidation : AbstractValidator<Contact>
{
    public ContactValidation()
    {
        RuleFor(x => x.DDD)
            .NotEqual(0)
            .WithMessage("Informe o DDD do contato.");

        RuleFor(x => x.PhoneNumber)
           .NotEqual(0)
           .WithMessage("Informe o Número do contato.");
    }
}
