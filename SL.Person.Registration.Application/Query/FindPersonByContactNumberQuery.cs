using MediatR;
using SL.Person.Registration.Domain.Results;

namespace SL.Person.Registration.Application.Query
{
    public class FindPersonByContactNumberQuery : IRequest<ResultBase>
    {
        public int Ddd { get; private set; }

        public long PhoneNumber { get; private set; }

        public FindPersonByContactNumberQuery(int ddd, long phoneNumber)
        {
            Ddd = ddd;
            PhoneNumber = phoneNumber;
        }
    }
}
