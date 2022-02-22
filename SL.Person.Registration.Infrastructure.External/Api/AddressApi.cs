using Newtonsoft.Json;
using SL.Person.Registratio.CrossCuting.Configurations.Contracts;
using SL.Person.Registration.Domain.External.Contracts;
using SL.Person.Registration.Domain.External.Response;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Infrastructure.External.Api
{
    public class AddressApi : IAddressApi
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfigurationPersonRegistration _configuration;

        public AddressApi(IHttpClientFactory httpClientFactory,
                          IConfigurationPersonRegistration configuration)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<AddressResponse> GetAddressByZipCode(string zipCode, CancellationToken cancellationToken)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, string.Format(_configuration.GetAddressApiSettings().GetAddressByZipCode, zipCode.Trim()));

            var client = _httpClientFactory.CreateClient();

            var response = await client.SendAsync(request, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<AddressResponse>(content);

                return string.IsNullOrWhiteSpace(result.Cep) ? null : result;
            }

            return null;
        }
    }
}
