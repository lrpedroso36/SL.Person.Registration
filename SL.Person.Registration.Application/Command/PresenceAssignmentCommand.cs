﻿using MediatR;

namespace SL.Person.Registration.Application.Command
{
    public class PresenceAssignmentCommand : IRequest
    {
        public string Id { get; private set; }

        public PresenceAssignmentCommand(string id)
        {
            Id = id;
        }
    }
}
