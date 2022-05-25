using MediatR;
using SL.Person.Registration.Domain.Requests;

namespace SL.Person.Registration.Application.Command
{
    public class InsertInterviewCommand : IRequest
    {
        public long InterviewedDocument { get; }

        public long InterviewerDocument { get; }

        public InterviewRequest Interview { get; }

        public InsertInterviewCommand(long interviewedDocument, long interviewerDocument, InterviewRequest interview)
        {
            InterviewedDocument = interviewedDocument;
            InterviewerDocument = interviewerDocument;
            Interview = interview;
        }
    }
}
