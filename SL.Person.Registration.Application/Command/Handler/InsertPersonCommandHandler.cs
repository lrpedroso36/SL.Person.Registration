﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SL.Person.Registration.Domain.RegistrationAggregate;
using SL.Person.Registration.Domain.Repositories;

namespace SL.Person.Registration.Application.Command.Hanler
{
    public class InsertPersonCommandHandler : IRequestHandler<InsertPersonCommand, bool>
    {
        private readonly IInformationRegistrationRepository _repository;

        public InsertPersonCommandHandler(IInformationRegistrationRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(InsertPersonCommand request, CancellationToken cancellationToken)
        {
            if(request.Person == null || request.Person.DocumentNumber == 0)
            {
                return false;
            }

            var person = request.Person.GetPersonRegistration();

            var registration = InformationRegistration.CreateInstance(person, null);

            _repository.Insert(registration);

            return true;
        }
    }
}
