using System;

namespace SL.Person.Registration.Domain.PersonAggregate
{
    public class Authentication
    {
        public string Password { get; private set; }

        protected Authentication()
        {

        }

        protected Authentication(string password)
        {
            Password = password;
        }

        public static Authentication CreateInstance(string password)
            => new Authentication(password);
    }
}
