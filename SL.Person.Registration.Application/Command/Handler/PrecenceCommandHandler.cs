using MediatR;
using SL.Person.Registration.Application.Command.Validations;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using SL.Person.Registration.Domain.PersonAggregate.Extensions;
using SL.Person.Registration.Domain.Repositories;
using SL.Person.Registration.Domain.Results.Contrats;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Command.Handler
{
    public class PrecenceCommandHandler : IRequestHandler<PrecenceCommand, IResult<bool>>
    {
        private readonly IPersonRegistrationRepository _personRegistrationRepository;

        public PrecenceCommandHandler(IPersonRegistrationRepository personRegistrationRepository)
        {
            _personRegistrationRepository = personRegistrationRepository;
        }

        public async Task<IResult<bool>> Handle(PrecenceCommand request, CancellationToken cancellationToken)
        {
            var result = request.RequestValidate();

            if (!result.IsSuccess)
            {
                return result;
            }

            var personInterviewed = _personRegistrationRepository.GetByDocument(request.InterviewedDocument, PersonType.Assistido);

            result = personInterviewed.ValidateInstanceByType<bool>(PersonType.Assistido);

            if (!result.IsSuccess)
            {
                return result;
            }

            var personLaborer = _personRegistrationRepository.GetByDocument(request.LaborerDocument);

            result = personLaborer.ValidateInstanceByType<bool>(PersonType.Tarefeiro);

            if (!result.IsSuccess)
            {
                return result;
            }

            personInterviewed.SetPresenceTratament(DateTime.Now, personLaborer);

            _personRegistrationRepository.Update(personInterviewed);

            result.SetData(true);

            return result;
        }
    }
}
