using SL.Person.Registration.Domain.Results.Contrats;
using SL.Person.Registration.Domain.Results.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace SL.Person.Registration.Domain.Results
{
    public class Result<T> : IResult<T>
    {
        public T Data { get; private set; }
        public bool IsSuccess { get { return !Errors.Any(); } }
        public List<string> Errors { get; private set; } = new List<string>();

        [JsonIgnore]
        public ErrorType ErrorType { get; private set; }

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

        public void SetData(T data)
        {
            Data = data;
        }
    }
}
