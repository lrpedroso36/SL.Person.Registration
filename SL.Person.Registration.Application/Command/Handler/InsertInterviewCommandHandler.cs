using MediatR;
using SL.Person.Registration.Application.Command.Validations;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using SL.Person.Registration.Domain.Repositories;
using SL.Person.Registration.Domain.Results.Contrats;
using SL.Person.Registration.Domain.Results.Enums;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Command.Handler
{
    public class InsertInterviewCommandHandler : IRequestHandler<InsertInterviewCommand, IResult<bool>>
    {
        private readonly IPersonRegistrationRepository _personRegistrationRepository;

        public InsertInterviewCommandHandler(IPersonRegistrationRepository personRegistrationRepository)
        {
            _personRegistrationRepository = personRegistrationRepository;
        }

        public async Task<IResult<bool>> Handle(InsertInterviewCommand request, CancellationToken cancellationToken)
        {
            var result = request.RequestValidate();

            if (!result.IsSuccess)
            {
                return result;
            }

            var person = _personRegistrationRepository.GetByDocument(request.Interview.DocumnetNumber);

            if (person == null)
            {
                result.AddErrors("Paciente não encontrado.", ErrorType.NotFoundData);
                return result;
            }

            var personInterview = _personRegistrationRepository.GetByDocument(request.Interview.DocumentNumberInterview, PersonType.Entrevistador);

            if (personInterview == null)
            {
                result.AddErrors("Entrevistador não encontrado.", ErrorType.NotFoundData);
                return result;
            }

            person.AddInterview(Interview.CreateInstance(request.Interview.TreatmentType, request.Interview.WeakDayType,
                request.Interview.Type, DateTime.Now, personInterview, request.Interview.Amount, request.Interview.Opinion));

            person.SetId(person._id);

            _personRegistrationRepository.Update(person);

            return result;
        }
    }
}
