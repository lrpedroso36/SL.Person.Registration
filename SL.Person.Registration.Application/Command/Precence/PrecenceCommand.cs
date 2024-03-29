﻿using MediatR;

namespace SL.Person.Registration.Application.Command.Precence;

public class PrecenceCommand : IRequest
{
    public string Id { get; private set; }

    public PrecenceCommand(string id)
    {
        Id = id;
    }
}
