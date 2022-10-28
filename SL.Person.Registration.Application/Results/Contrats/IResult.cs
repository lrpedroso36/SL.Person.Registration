namespace SL.Person.Registration.Application.Results.Contrats;

public interface IResult<T>
{
    T Data { get; }
    public void SetData(T data);
}
