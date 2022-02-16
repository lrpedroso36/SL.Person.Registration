using MediatR;
using SL.Person.Registration.Application.Command.Validations;
using SL.Person.Registration.Domain.PersonAggregate.Extensions;
using SL.Person.Registration.Domain.Repositories;
using SL.Person.Registration.Domain.Results.Contrats;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Command.Handler
{
    public class ContactCommandHandler : IRequestHandler<ContactCommand, IResult<bool>>
    {
        private readonly IPersonRegistrationRepository _repository;

        public ContactCommandHandler(IPersonRegistrationRepository repository)
        {
            _repository = repository;
        }

        public async Task<IResult<bool>> Handle(ContactCommand request, CancellationToken cancellationToken)
        {
            var result = request.RequestValidate();

            if (!result.IsSuccess)
            {
                return result;
            }

            var personRegistration = _repository.GetByDocument(request.DocumentNumber);

            result = personRegistration.ValidateInstance<bool>();

            if (!result.IsSuccess)
            {
                return result;
            }

            var contact = request.Contact.GetContact();

            result = contact.Validate<bool>();

            if (!result.IsSuccess)
            {
                return result;
            }

            personRegistration.AddContact(contact);

            _repository.Update(personRegistration);

            result.SetData(true);

            return result;
        }
    }
}
