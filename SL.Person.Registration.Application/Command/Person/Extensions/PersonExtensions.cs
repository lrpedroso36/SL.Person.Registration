using SL.Person.Registration.Application.Command.Person.Insert;
using SL.Person.Registration.Application.Command.Person.Update;
using SL.Person.Registration.Application.Commons.Exceptions;
using SL.Person.Registration.Application.Commons.Extensions;
using SL.Person.Registration.Application.Commons.Responses;
using SL.Person.Registration.Application.Commons.Responses.Enums;
using SL.Person.Registration.CrossCuting.Resources;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Validations;

namespace SL.Person.Registration.Application.Command.Person.Extensions;

public static class PersonExtensions
{
    public static void RequestValidate(this InsertPersonCommand request)
    {
        if (request.Person == null || request.Person.DocumentNumber == 0)
        {
            var result = new Result();
            result.ToInvalidParameter(ResourceMessagesValidation.InsertPersonCommandValidation_RequestInvalid);
            throw new ApplicationRequestException(result);
        }
    }

    public static void RequestValidate(this UpdatePersonCommand request)
    {
        if (request.Person == null || request.Person.DocumentNumber == 0)
        {
            var result = new Result();
            result.ToInvalidParameter(ResourceMessagesValidation.UpdatePersonCommandValidation_RequestInvalid);
            throw new ApplicationRequestException(result);
        }
    }

    public static void ValidateFoundInstance(this PersonRegistration person)
    {
        if (person != null)
        {
            var result = new Result();
            result.ToNotFound(ResourceMessagesValidation.InsertPersonCommandHandler_Found);
            throw new ApplicationRequestException(result);
        }
    }

    public static void ValidateIsNotFoundInstance(this PersonRegistration person)
    {
        var validation = new PersonRegistrationInstanceValidation()
            .Validate(person);

        if (!validation.IsValid)
        {
            var result = new ResultEntities<PersonRegistration>();
            result.SetErrorType(ErrorType.NotFoundData);
            validation.Errors.ForEach(error => result.AddErrors(error.ErrorMessage));
            throw new ApplicationRequestException(result);
        }
    }

    public static void Validate(this PersonRegistration person)
    {
        var validation = new PersonRegistrationValidation()
            .Validate(person);

        if (!validation.IsValid)
        {
            var result = new Result();
            result.ToEntitiesProperty(validation);
            throw new DomainException(result);
        }
    }
}
