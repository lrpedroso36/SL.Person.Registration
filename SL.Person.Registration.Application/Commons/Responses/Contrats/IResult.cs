namespace SL.Person.Registration.Application.Commons.Responses.Contrats;

public interface IResult<T>
{
    T Data { get; }
    public void SetData(T data);
}
