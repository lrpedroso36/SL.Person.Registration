namespace SL.Person.Registration.Domain.PersonAggregate;

public class Contact
{
    public string Number { get; private set; }

    protected Contact()
    {

    }

    protected Contact(string number)
    {
        Number = number;
    }

    public static Contact CreateInstance(string number)
        => new(number);
}
