using FluentValidation;
using FluentValidation.Results;
using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using System.Collections.Generic;

namespace SL.Person.Registration.Domain.PersonAggregate.Validations
{
    public class PersonRegistrationInstanceValidation : AbstractValidator<PersonRegistration>
    {
        private readonly Dictionary<PersonType, string> invalidInstanceMessages = new Dictionary<PersonType, string>()
        {
            { PersonType.Tarefeiro , ResourceMessagesValidation.PersonRegistrationLabore_InstanceInvalid },
            { PersonType.Assistido, ResourceMessagesValidation.PersonRegistrationWatched_InstanceInvalid },
            { PersonType.Palestrante, ResourceMessagesValidation.PersonRegistrationSpeaker_InstanceInvalid },
            { PersonType.Entrevistador, ResourceMessagesValidation.PersonRegistrationInterviewer_InstanceInvalid }
        };

        private readonly string instanceInvalidTypeMessage;

        public PersonRegistrationInstanceValidation(PersonType personType)
        {
            instanceInvalidTypeMessage = invalidInstanceMessages[personType];
        }

        public PersonRegistrationInstanceValidation()
        {
            instanceInvalidTypeMessage = ResourceMessagesValidation.PersonRegistration_InstanceInvalid;
        }

        public override ValidationResult Validate(ValidationContext<PersonRegistration> context)
        {
            return context?.InstanceToValidate == null
                ? new ValidationResult(new[] { new ValidationFailure("instance", instanceInvalidTypeMessage) })
                : base.Validate(context);
        }
    }
}
