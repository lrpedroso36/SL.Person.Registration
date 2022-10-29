using SL.Person.Registration.Domain.PersonAggregate;

namespace SL.Person.Registration.Application.Query.FindPeople.Responses;

public class FindTratamentResponse
{
    public string Date { get; private set; }

    public string Presence { get; private set; }

    public static explicit operator FindTratamentResponse(Tratament tratament)
    {
        var result = new FindTratamentResponse
        {
            Date = tratament.Date.ToShortDateString(),
            Presence = tratament.Presence != null && tratament.Presence.Value ? "Confirmada" : "Não confirmada"
        };
        return result;
    }
}
