using FluentValidation;
using FluentValidation.Results;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using SL.Person.Registration.Domain.Resources;
using System.Collections.Generic;

namespace SL.Person.Registration.Domain.PersonAggregate.Validations
{
    public class PersonRegistrationInstanceValidation : AbstractValidator<PersonRegistration>
    {
        private readonly Dictionary<PersonType, string> invalidInstanceMessages = new Dictionary<PersonType, string>()
        {
            { PersonType.Tarefeiro , DomainMessages.PersonRegistrationLabore_InstanceInvalid },
            { PersonType.Assistido, DomainMessages.PersonRegistrationWatched_InstanceInvalid },
            { PersonType.Palestrante, DomainMessages.PersonRegistrationSpeaker_InstanceInvalid },
            { PersonType.Entrevistador, DomainMessages.PersonRegistrationInterviewer_InstanceInvalid }
        };

        private readonly string instanceInvalidTypeMessage;

        public PersonRegistrationInstanceValidation(PersonType personType)
        {
            instanceInvalidTypeMessage = invalidInstanceMessages[personType];
        }

        public PersonRegistrationInstanceValidation()
        {
            instanceInvalidTypeMessage = DomainMessages.PersonRegistration_InstanceInvalid;
        }

        public override ValidationResult Validate(ValidationContext<PersonRegistration> context)
        {
            return context?.InstanceToValidate == null
                ? new ValidationResult(new[] { new ValidationFailure("instance", instanceInvalidTypeMessage) })
                : base.Validate(context);
        }
    }
}
