﻿using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using System;
using System.Linq;

namespace SL.Person.Registration.Domain.PersonAggregate
{
    public class Tratament
    {
        public DateTime Date { get; private set; }

        public PersonRegistration TaskMaster { get; private set; }

        public bool? Presence { get; private set; }

        protected Tratament()
        {

        }

        private Tratament(DateTime date, PersonRegistration taskMaster)
        {
            Date = date;
            TaskMaster = SetTaskMaster(taskMaster);
        }

        private Tratament(DateTime date, PersonRegistration taskMaster, bool presence) : this(date, taskMaster)
        {

            Presence = presence;
        }

        private PersonRegistration SetTaskMaster(PersonRegistration taskMaster)
        {
            if (taskMaster != null && taskMaster.Types.Any(x => x == PersonType.Tarefeiro))
            {
                return PersonRegistration.CreateInstance(taskMaster._id, taskMaster.Types, taskMaster.Name, taskMaster.DocumentNumber);
            }

            return null;
        }

        public static Tratament CreateInstance(DateTime date, PersonRegistration taskMaster)
            => new Tratament(date, taskMaster);

        public static Tratament CreateInstance(DateTime date, PersonRegistration taskMaster, bool presence)
            => new Tratament(date, taskMaster, presence);

        public void SetPresence(DateTime date, PersonRegistration taskMaster)
        {
            Date = date;
            TaskMaster = SetTaskMaster(taskMaster);
            Presence = true;
        }
    }
}