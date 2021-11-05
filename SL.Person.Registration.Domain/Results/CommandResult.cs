using System.Collections.Generic;
using System.Linq;

namespace SL.Person.Registration.Domain.Results
{
    public class CommandResult
    {

        public bool Sucess { get; private set; }

        public List<string> Errors { get; private set; }

        public void AddErrors(string error)
        {
            if (Errors == null)
            {
                Errors = new List<string>();
            }

            if (!string.IsNullOrWhiteSpace(error))
            {
                Errors.Add(error);
            }

            Sucess = !(Errors != null && !Errors.Any());
        }
    }
}
