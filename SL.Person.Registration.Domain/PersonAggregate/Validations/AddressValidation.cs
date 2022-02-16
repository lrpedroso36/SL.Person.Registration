using FluentValidation;
using SL.Person.Registratio.CrossCuting.Resources;

namespace SL.Person.Registration.Domain.PersonAggregate.Validations
{
    public class AddressValidation : AbstractValidator<Address>
    {
        public AddressValidation()
        {
            RuleFor(x => x.ZipCode)
                .NotEqual(0)
                .WithMessage(ResourceMessagesValidation.AddressValidation_ZipCode);

            RuleFor(x => x.Street)
               .NotEmpty()
               .WithMessage(ResourceMessagesValidation.AddressValidation_Street)
               .NotNull()
               .WithMessage(ResourceMessagesValidation.AddressValidation_Street);

            RuleFor(x => x.Number)
               .NotEmpty()
               .WithMessage(ResourceMessagesValidation.AddressValidation_Number)
               .NotNull()
               .WithMessage(ResourceMessagesValidation.AddressValidation_Number);

            RuleFor(x => x.Neighborhood)
               .NotEmpty()
               .WithMessage(ResourceMessagesValidation.AddressValidation_Neighborhood)
               .NotNull()
               .WithMessage(ResourceMessagesValidation.AddressValidation_Neighborhood);

            RuleFor(x => x.City)
               .NotEmpty()
               .WithMessage(ResourceMessagesValidation.AddressValidation_City)
               .NotNull()
               .WithMessage(ResourceMessagesValidation.AddressValidation_City);

            RuleFor(x => x.State)
               .NotEmpty()
               .WithMessage(ResourceMessagesValidation.AddressValidation_State)
               .NotNull()
               .WithMessage(ResourceMessagesValidation.AddressValidation_State);

        }
    }
}
