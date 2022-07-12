using FluentValidation;
using SL.Person.Registration.Domain.Resources;

namespace SL.Person.Registration.Domain.PersonAggregate.Validations
{
    public class ContactValidation : AbstractValidator<Contact>
    {
        public ContactValidation()
        {
            RuleFor(x => x.DDD)
                .NotEqual(0)
                .WithMessage(DomainMessages.ContactValidation_DDD);

            RuleFor(x => x.PhoneNumber)
               .NotEqual(0)
               .WithMessage(DomainMessages.ContactValidation_PhoneNumber);
        }
    }
}
