using SL.Person.Registration.Application.Commons.Exceptions;
using SL.Person.Registration.Application.Commons.Responses;
using SL.Person.Registration.Application.Commons.Responses.Extensions;
using SL.Person.Registration.Application.Query.FindPeople.Responses;
using SL.Person.Registration.Domain.PersonAggregate;
using System.Collections.Generic;
using System.Linq;

namespace SL.Person.Registration.Application.Query.FindPeople.Extensions;

public static class FindPeopleExtensions
{
    public static void RequestValidate(this FindPeopleQuery request)
    {
        if (string.IsNullOrWhiteSpace(request.Name) && request.DocumentNumber == 0 && !request.PersonType.HasValue)
        {
            var result = new ResponseEntities<IEnumerable<FindPersonResponse>>();
            result.ToInvalidParameter("Informe o nome, o documento ou o tipo de pessoa que deseja fazer a pesquisa.");
            throw new ApplicationRequestException(result);
        }
    }

    public static void ValidateList(this IEnumerable<PersonRegistration> persons)
    {
        if (persons == null || !persons.Any())
        {
            var result = new Response();
            result.ToNotFound("A pesquisa não retornou nenhum resultado.");
            throw new ApplicationRequestException(result);
        }
    }
}
