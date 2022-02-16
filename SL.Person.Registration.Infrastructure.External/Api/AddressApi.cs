using Newtonsoft.Json;
using SL.Person.Registration.Domain.External.Contracts;
using SL.Person.Registration.Domain.External.Response;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Infrastructure.External.Api
{
    public class AddressApi : IAddressApi
    {
        private readonly string GET_URL_ZIP_CODE = "https://viacep.com.br/ws/{0}/json/";

        private readonly IHttpClientFactory _httpClientFactory;

        public AddressApi(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<AddressResponse> GetAddressByZipCode(string zipCode, CancellationToken cancellationToken)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, string.Format(GET_URL_ZIP_CODE, zipCode));

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
