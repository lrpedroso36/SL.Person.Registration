using SL.Person.Registratio.CrossCuting.Extensions;
using SL.Person.Registration.Domain.PersonAggregate;
using System.Collections.Generic;
using System.Linq;

namespace SL.Person.Registration.Application.Query.FindPeople.Responses;

public class FindInterviewResponse
{
    public string TreatmentType { get; set; }

    public string WeakDayType { get; set; }

    public string Type { get; set; }

    public string Date { get; set; }

    public string Status { get; set; }

    public string Interviewer { get; set; }

    public int Amount { get; set; }

    public string Opinion { get; set; }

    public List<FindTratamentResponse> Trataments { get; set; } = new List<FindTratamentResponse>();


    public static explicit operator FindInterviewResponse(Interview interview)
    {

        var result = new FindInterviewResponse()
        {
            TreatmentType = interview.TreatmentType.GetDescription(),
            WeakDayType = interview.WeakDayType.GetDescription(),
            Type = interview.InterviewType.GetDescription(),
            Date = interview.Date.ToShortDateString(),
            Status = interview.Status.GetDescription(),
            Interviewer = interview.Interviewer.Name,
            Amount = interview.Amount,
            Opinion = interview.Opinion,
            Trataments = interview.Trataments.OrderByDescending(x => x.Date).Select(x => (FindTratamentResponse)x).ToList()
        };

        return result;
    }
}
