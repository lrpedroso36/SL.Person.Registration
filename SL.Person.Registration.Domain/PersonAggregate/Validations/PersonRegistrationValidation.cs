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
}
