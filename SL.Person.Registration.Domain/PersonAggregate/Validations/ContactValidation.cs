using FluentValidation;

namespace SL.Person.Registration.Domain.PersonAggregate.Validations;

public class ContactValidation : AbstractValidator<Contact>
{
    public ContactValidation()
    {
        RuleFor(x => x.Number)
           .NotNull()
           .NotEmpty()
           .WithMessage("Informe o Número do contato.");
    }
}
