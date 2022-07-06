using SL.Person.Registration.Domain.PersonAggregate;
using System;

namespace SL.Person.Registration.Domain.Results
{
    public class FindAssignmentResult
    {
        public string Date { get; private set; }

        public string Presence { get; private set; }

        public static explicit operator FindAssignmentResult(Assignment assignment)
        {
            var result = new FindAssignmentResult
            {
                Date = assignment.Date.ToShortDateString(),
                Presence = assignment.Presence ? "Confirmada" : "Não confirmada"
            };
            return result;
        }

    }
}
