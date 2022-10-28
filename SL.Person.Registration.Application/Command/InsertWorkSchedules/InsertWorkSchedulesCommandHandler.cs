using MediatR;
using SL.Person.Registration.Application.Extensions;
using SL.Person.Registration.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Command.InsertWorkSchedules;

public class InsertWorkSchedulesCommandHandler : IRequestHandler<InsertWorkSchedulesCommand>
{
    private readonly IPersonRegistrationRepository _repository;

    public InsertWorkSchedulesCommandHandler(IPersonRegistrationRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(InsertWorkSchedulesCommand request, CancellationToken cancellationToken)
    {
        request.RequestValidate();

        var personResult = _repository.GetById(request.Id);

        personResult.ValidateInstance();

        foreach (var item in request.Works)
        {
            personResult.SetWorkSchedules(item.WeakDayType, item.Date, item.DoTheReading);
        }

        _repository.Update(personResult);

        return Unit.Value;
    }
}
