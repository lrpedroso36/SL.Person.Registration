namespace SL.Person.Registration.Application.Commons.Responses.Contrats;

public interface IResponse<T>
{
    T Data { get; }
    public void SetData(T data);
}
