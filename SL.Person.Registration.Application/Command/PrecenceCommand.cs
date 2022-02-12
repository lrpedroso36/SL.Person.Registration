using MediatR;
using SL.Person.Registration.Domain.Results.Contrats;

namespace SL.Person.Registration.Application.Command
{
    public class PrecenceCommand : IRequest<IResult<bool>>
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
