using MediatR;
using SL.Person.Registration.Application.Requests;

namespace SL.Person.Registration.Application.Command
{
    public class InsertInterviewCommand : IRequest
    {
        public string InterviewedId { get; }

        public string InterviewerId { get; }

        public InterviewRequest Interview { get; }

        public InsertInterviewCommand(string interviewedId, string interviewerId, InterviewRequest interview)
        {
            InterviewedId = interviewedId;
            InterviewerId = interviewerId;
            Interview = interview;
        }
    }
}
