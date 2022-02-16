using FluentValidation;
using SL.Person.Registratio.CrossCuting.Resources;

namespace SL.Person.Registration.Domain.PersonAggregate.Validations
{
    public class PersonRegistrationValidation : AbstractValidator<PersonRegistration>
    {
        public PersonRegistrationValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(ResourceMessagesValidation.PersonRegistrationValidation_Name)
                .NotNull()
                .WithMessage(ResourceMessagesValidation.PersonRegistrationValidation_Name);

            RuleFor(x => x.DocumentNumber)
                .NotEqual(0)
                .WithMessage(ResourceMessagesValidation.PersonRegistrationValidation_DocumentNumber);
        }
    }
}
