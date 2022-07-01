using MediatR;

namespace SL.Person.Registration.Application.Command
{
    public class PrecenceCommand : IRequest
    {
        public long InterviewedDocument { get; private set; }

        public PrecenceCommand(long interviewedDocument)
        {
            InterviewedDocument = interviewedDocument;
        }
    }
}
