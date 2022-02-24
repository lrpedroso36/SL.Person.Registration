using MediatR;

namespace SL.Person.Registration.Application.Command
{
    public class PresenceAssignmentCommand : IRequest
    {
        public long LaborerDocument { get; private set; }

        public PresenceAssignmentCommand(long laborerDocument)
        {
            LaborerDocument = laborerDocument;
        }
    }
}
