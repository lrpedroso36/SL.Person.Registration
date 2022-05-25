using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using System.Diagnostics.CodeAnalysis;

namespace SL.Person.Registration.Domain.Requests
{
    [ExcludeFromCodeCoverage]
    public class InterviewRequest
    {
        public TreatmentType TreatmentType { get; set; }

        public WeakDayType WeakDayType { get; set; }

        public InterviewType Type { get; set; }

        public int Amount { get; set; }

        public string Opinion { get; set; }
    }
}
