using SL.Person.Registration.Domain.PersonAggregate.Enuns;

namespace SL.Person.Registration.Domain.Requests
{
    public class InterviewRequest
    {
        public long DocumnetNumber { get; set; }

        public long DocumentNumberInterview { get; set; }

        public TreatmentType TreatmentType { get; set; }

        public WeakDayType WeakDayType { get; set; }

        public InterviewType Type { get; set; }

        public int Amount { get; set; }

        public string Opinion { get; set; }
    }
}
