﻿using MediatR;
using SL.Person.Registration.Application.Command.Validations;
using SL.Person.Registration.Domain.PersonAggregate.Extensions;
using SL.Person.Registration.Domain.Repositories;
using SL.Person.Registration.Domain.Results;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Command.Handler
{
    public class AddressCommandHandler : IRequestHandler<AddressCommand, ResultBase>
    {
        private readonly IPersonRegistrationRepository _repository;

        public AddressCommandHandler(IPersonRegistrationRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultBase> Handle(AddressCommand request, CancellationToken cancellationToken)
        {
            var result = request.RequestValidate();

            if (!result.IsSuccess)
            {
                return result;
            }

            var personRegistration = _repository.GetByDocument(request.DocumentNumber);

            result = personRegistration.ValidateInstance();

            if (!result.IsSuccess)
            {
                return result;
            }

            var address = request.Address.GetAddress();

            result = address.Validate();

            if (!result.IsSuccess)
            {
                return result;
            }

            personRegistration.AddAdress(address);

            _repository.Update(personRegistration);

            return result;
        }
    }
}
