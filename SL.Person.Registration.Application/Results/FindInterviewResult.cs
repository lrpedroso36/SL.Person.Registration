using SL.Person.Registratio.CrossCuting.Extensions;
using SL.Person.Registration.Domain.PersonAggregate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SL.Person.Registration.Application.Results
{
    public class FindInterviewResult
    {
        public string TreatmentType { get; set; }

        public string WeakDayType { get; set; }

        public string Type { get; set; }

        public string Date { get; set; }

        public string Status { get; set; }

        public string Interviewer { get; set; }

        public int Amount { get; set; }

        public string Opinion { get; set; }

        public List<FindTratamentResult> Trataments { get; set; } = new List<FindTratamentResult>();


        public static explicit operator FindInterviewResult(Interview interview)
        {

            var result = new FindInterviewResult()
            {
                TreatmentType = interview.TreatmentType.GetDescription(),
                WeakDayType = interview.WeakDayType.GetDescription(),
                Type = interview.Type.GetDescription(),
                Date = interview.Date.ToShortDateString(),
                Status = interview.Status.GetDescription(),
                Interviewer = interview.Interviewer.Name,
                Amount = interview.Amount,
                Opinion = interview.Opinion,
                Trataments = interview.Trataments.OrderByDescending(x => x.Date).Select(x => (FindTratamentResult)x).ToList()
            };

            return result;
        }
    }
}
