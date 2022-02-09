using System.Collections.Generic;

namespace SL.Person.Registration.Domain.Results.Contrats
{
    public interface IResult<T>
    {
        T Data { get; }
        bool IsSuccess { get; }
        List<string> Errors { get; }
        public void AddErrors(string error);
        public void SetData(T data);
    }
}
