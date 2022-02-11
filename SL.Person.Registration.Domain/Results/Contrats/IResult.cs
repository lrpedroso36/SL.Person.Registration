using SL.Person.Registration.Domain.Results.Enums;
using System.Collections.Generic;

namespace SL.Person.Registration.Domain.Results.Contrats
{
    public interface IResult<T>
    {
        T Data { get; }
        bool IsSuccess { get; }
        public ErrorType ErrorType { get; }
        List<string> Errors { get; }
        public void AddErrors(string error, ErrorType errorType);
        public void SetData(T data);
    }
}
