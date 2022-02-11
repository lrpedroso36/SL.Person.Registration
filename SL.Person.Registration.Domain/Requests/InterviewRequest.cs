using SL.Person.Registration.Domain.PersonAggregate.Enuns;

namespace SL.Person.Registration.Domain.Requests
{
    public class InterviewRequest
    {
        public long Interviewed { get; set; }

        public long Interviewer { get; set; }

        public TreatmentType TreatmentType { get; set; }

        public WeakDayType WeakDayType { get; set; }

        public InterviewType Type { get; set; }

        public int Amount { get; set; }

        public string Opinion { get; set; }
    }
}
