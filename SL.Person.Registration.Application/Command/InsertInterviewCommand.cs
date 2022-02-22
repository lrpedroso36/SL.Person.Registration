using MediatR;
using SL.Person.Registration.Domain.Requests;

namespace SL.Person.Registration.Application.Command
{
    public class InsertInterviewCommand : IRequest
    {
        public InsertInterviewCommand(InterviewRequest interview)
        {
            Interview = interview;
        }

        public InterviewRequest Interview { get; }
    }
}
