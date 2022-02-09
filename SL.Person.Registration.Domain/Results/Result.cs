using SL.Person.Registration.Domain.Results.Contrats;
using System.Collections.Generic;
using System.Linq;

namespace SL.Person.Registration.Domain.Results.Base
{
    public class Result<T> : IResult<T>
    {
        public T Data { get; private set; }
        public bool IsSuccess { get { return !Errors.Any(); } }
        public List<string> Errors { get; private set; } = new List<string>();

        public void AddErrors(string error)
        {
            if (Errors == null)
            {
                Errors = new List<string>();
            }

            if (!string.IsNullOrWhiteSpace(error) && !Errors.Contains(error))
                Errors.Add(error);
        }

        public void SetData(T data)
        {
            Data = data;
        }
    }
}
