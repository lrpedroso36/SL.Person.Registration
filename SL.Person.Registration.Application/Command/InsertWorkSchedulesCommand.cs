using MediatR;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using System;
using System.Collections.Generic;

namespace SL.Person.Registration.Application.Command
{
    public class InsertWorkSchedulesCommand : IRequest
    {
        public string Id { get; }
        public List<WorkScheduleCommand> Works { get; } = new List<WorkScheduleCommand>();

        public InsertWorkSchedulesCommand(string id, List<WorkScheduleCommand> works)
        {
            Id = id;
            Works = works;
        }

        public class WorkScheduleCommand
        {
            public WeakDayType WeakDayType { get; set; }
            public DateTime Date { get; set; }
            public bool DoTheReading { get; set; }
        }
    }
}
