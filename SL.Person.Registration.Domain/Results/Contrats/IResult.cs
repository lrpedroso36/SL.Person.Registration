namespace SL.Person.Registration.Domain.Results.Contrats
{
    public interface IResult<T>
    {
        T Data { get; }
        public void SetData(T data);
    }
}
