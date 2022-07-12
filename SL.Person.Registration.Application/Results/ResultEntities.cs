using SL.Person.Registration.Application.Results.Base;
using SL.Person.Registration.Application.Results.Contrats;

namespace SL.Person.Registration.Application.Results
{
    public class ResultEntities<T> : ResultBase, IResult<T> where T : class
    {
        public T Data { get; private set; }

        public void SetData(T data)
        {
            Data = data;
        }
    }
}
