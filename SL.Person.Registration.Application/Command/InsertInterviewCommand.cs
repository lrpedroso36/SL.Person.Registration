using MediatR;
using SL.Person.Registration.Domain.Requests;
using SL.Person.Registration.Domain.Results.Contrats;

namespace SL.Person.Registration.Application.Command
{
    public class InsertInterviewCommand : IRequest<IResult<bool>>
    {
        public InsertInterviewCommand(InterviewRequest interview)
        {
            Interview = interview;
        }

        public InterviewRequest Interview { get; }
    }
}
