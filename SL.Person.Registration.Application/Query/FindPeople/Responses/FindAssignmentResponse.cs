using SL.Person.Registration.Domain.PersonAggregate;

namespace SL.Person.Registration.Application.Query.FindPeople.Responses;

public class FindAssignmentResponse
{
    public string Date { get; private set; }

    public string Presence { get; private set; }

    public static explicit operator FindAssignmentResponse(Assignment assignment)
    {
        var result = new FindAssignmentResponse
        {
            Date = assignment.Date.ToShortDateString(),
            Presence = assignment.Presence ? "Confirmada" : "Não confirmada"
        };
        return result;
    }

}
