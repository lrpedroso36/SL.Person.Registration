using FluentValidation;
using SL.Person.Registration.Domain.Resources;

namespace SL.Person.Registration.Domain.PersonAggregate.Validations
{
    public class AddressValidation : AbstractValidator<Address>
    {
        public AddressValidation()
        {
            RuleFor(x => x.ZipCode)
               .NotEmpty()
               .WithMessage(DomainMessages.AddressValidation_ZipCode)
               .NotNull()
               .WithMessage(DomainMessages.AddressValidation_ZipCode);

            RuleFor(x => x.Street)
               .NotEmpty()
               .WithMessage(DomainMessages.AddressValidation_Street)
               .NotNull()
               .WithMessage(DomainMessages.AddressValidation_Street);

            RuleFor(x => x.Number)
               .NotEmpty()
               .WithMessage(DomainMessages.AddressValidation_Number)
               .NotNull()
               .WithMessage(DomainMessages.AddressValidation_Number);

            RuleFor(x => x.Neighborhood)
               .NotEmpty()
               .WithMessage(DomainMessages.AddressValidation_Neighborhood)
               .NotNull()
               .WithMessage(DomainMessages.AddressValidation_Neighborhood);

            RuleFor(x => x.City)
               .NotEmpty()
               .WithMessage(DomainMessages.AddressValidation_City)
               .NotNull()
               .WithMessage(DomainMessages.AddressValidation_City);

            RuleFor(x => x.State)
               .NotEmpty()
               .WithMessage(DomainMessages.AddressValidation_State)
               .NotNull()
               .WithMessage(DomainMessages.AddressValidation_State);

        }
    }
}
