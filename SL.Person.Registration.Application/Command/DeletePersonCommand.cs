using MediatR;

namespace SL.Person.Registration.Application.Command
{
    public class DeletePersonCommand : IRequest
    {
        public long DocumentNumber { get; private set; }

        public DeletePersonCommand(long documentNumber)
        {
            DocumentNumber = documentNumber;
        }
    }
}
