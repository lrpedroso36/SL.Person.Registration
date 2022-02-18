using SL.Person.Registration.Domain.Results.Base;
using SL.Person.Registration.Domain.Results.Contrats;

namespace SL.Person.Registration.Domain.Results
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
