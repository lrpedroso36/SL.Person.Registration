using SL.Person.Registration.Domain.PersonAggregate;

namespace SL.Person.Registration.Application.Results;

public class FindTratamentResult
{
    public string Date { get; private set; }

    public string Presence { get; private set; }

    public static explicit operator FindTratamentResult(Tratament tratament)
    {
        var result = new FindTratamentResult
        {
            Date = tratament.Date.ToShortDateString(),
            Presence = tratament.Presence != null && tratament.Presence.Value ? "Confirmada" : "Não confirmada"
        };
        return result;
    }
}
