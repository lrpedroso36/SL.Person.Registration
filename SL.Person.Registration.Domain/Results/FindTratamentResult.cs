using SL.Person.Registration.Domain.PersonAggregate;
using System;

namespace SL.Person.Registration.Domain.Results
{
    public class FindTratamentResult
    {
        public string Id
        {
            get { return Guid.NewGuid().ToString(); }
        }
        public string Date { get; private set; }

        public string Presence { get; private set; }

        public static explicit operator FindTratamentResult(Tratament tratament)
        {
            var result = new FindTratamentResult
            {
                Date = tratament.Date.ToShortDateString(),
                Presence = tratament.Presence != null && tratament.Presence.Value ? "Confirmada" : "Não confirmada"
            };
            return result;
        }
    }
}
