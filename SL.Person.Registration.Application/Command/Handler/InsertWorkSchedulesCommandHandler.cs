using MediatR;
using SL.Person.Registration.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Command.Handler
{
    public class InsertWorkSchedulesCommandHandler : IRequestHandler<InsertWorkSchedulesCommand>
    {
        private readonly IPersonRegistrationRepository _repository;

        public InsertWorkSchedulesCommandHandler(IPersonRegistrationRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(InsertWorkSchedulesCommand request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}
