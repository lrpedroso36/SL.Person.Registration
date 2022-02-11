using MediatR;
using SL.Person.Registration.Domain.Results.Contrats;

namespace SL.Person.Registration.Application.Command
{
    public class PrecenceCommand : IRequest<IResult<bool>>
    {
        public long Interviewed { get; private set; }
        public long TaskMaster { get; private set; }

        public PrecenceCommand(long interviewed, long taskMaster)
        {
            Interviewed = interviewed;
            TaskMaster = taskMaster;
        }
    }
}
