using MediatR;
using SL.Person.Registration.Application.Command.DeletePerson.Extensions;
using SL.Person.Registration.Application.Command.Person.Extensions;
using SL.Person.Registration.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Command.DeletePerson;

public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand>
{
    private readonly IPersonRegistrationRepository _repository;

    public DeletePersonCommandHandler(IPersonRegistrationRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
    {
        request.RequestValidate();

        var personRegistration = _repository.GetById(request.Id);

        personRegistration.ValidateIsNotFoundInstance();

        personRegistration.SetIsExcluded();

        _repository.Update(personRegistration);

        return Unit.Value;
    }
}
