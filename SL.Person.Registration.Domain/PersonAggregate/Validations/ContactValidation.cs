using FluentValidation;
using SL.Person.Registratio.CrossCuting.Resources;

namespace SL.Person.Registration.Domain.PersonAggregate.Validations
{
    public class ContactValidation : AbstractValidator<Contact>
    {
        public ContactValidation()
        {
            RuleFor(x => x.DDD)
                .NotEqual(0)
                .WithMessage(ResourceMessagesValidation.ContactValidation_DDD);

            RuleFor(x => x.PhoneNumber)
               .NotEqual(0)
               .WithMessage(ResourceMessagesValidation.ContactValidation_PhoneNumber);
        }
    }
}
