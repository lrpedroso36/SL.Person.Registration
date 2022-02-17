using SL.Person.Registration.Domain.PersonAggregate;

namespace SL.Person.Registration.Domain.External.Response
{
    public class AddressResponse
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }

        public Address GetAddress()
        {
            if (string.IsNullOrWhiteSpace(Cep))
                return null;

            var zipCode = GetZipCode(Cep);

            return Address.CreateInstance(zipCode, Logradouro, null, Bairro, null, Localidade, Uf);
        }

        private long GetZipCode(string cep)
        {
            if (long.TryParse(cep.Replace("-", string.Empty), out long zipCode))
                return zipCode;

            return 0;
        }
    }
}
