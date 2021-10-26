﻿using MediatR;
using SL.Person.Registration.Domain.Results;

namespace SL.Person.Registration.Application.Query
{
    public class FindPersonByDocumentQuery : IRequest<FindPersonResult>
    {
        public FindPersonByDocumentQuery(long documentNumber)
        {
            DocumentNumber = documentNumber;
        }

        public long DocumentNumber { get; }
    }
}