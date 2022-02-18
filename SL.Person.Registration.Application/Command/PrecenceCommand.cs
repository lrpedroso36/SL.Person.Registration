using MediatR;
using SL.Person.Registration.Domain.Results;

namespace SL.Person.Registration.Application.Command
{
    public class PrecenceCommand : IRequest
    {
        public long InterviewedDocument { get; private set; }
        public long LaborerDocument { get; private set; }

        public PrecenceCommand(long interviewedDocument, long laborerDocument)
        {
            InterviewedDocument = interviewedDocument;
            LaborerDocument = laborerDocument;
        }
    }
}
