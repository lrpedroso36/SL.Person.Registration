using MediatR;
using SL.Person.Registration.Application.Command.Validations;
using SL.Person.Registration.Application.Extensions;
using SL.Person.Registration.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Application.Command.Handler
{
    public class ContactCommandHandler : IRequestHandler<ContactCommand>
    {
        private readonly IPersonRegistrationRepository _repository;

        public ContactCommandHandler(IPersonRegistrationRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(ContactCommand request, CancellationToken cancellationToken)
        {
            request.RequestValidate();

            var personRegistration = _repository.GetByDocument(request.DocumentNumber);

            personRegistration.ValidateInstance();

            var contact = request.Contact.GetContact();

            contact.Validate();

            personRegistration.AddContact(contact);

            _repository.Update(personRegistration);

            return Unit.Value;
        }
    }
}
