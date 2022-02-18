using SL.Person.Registration.Domain.Results.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace SL.Person.Registration.Domain.Results.Base
{
    public abstract class ResultBase
    {
        [JsonIgnore]
        public ErrorType ErrorType { get; private set; }

        [JsonIgnore]
        public bool IsSuccess { get { return !Errors.Any(); } }

        public List<string> Errors { get; private set; } = new List<string>();

        public void AddErrors(string error, ErrorType errorType)
        {
            if (Errors == null)
            {
                Errors = new List<string>();
            }

            if (!string.IsNullOrWhiteSpace(error) && !Errors.Contains(error))
                Errors.Add(error);

            ErrorType = errorType;
        }
    }
}
