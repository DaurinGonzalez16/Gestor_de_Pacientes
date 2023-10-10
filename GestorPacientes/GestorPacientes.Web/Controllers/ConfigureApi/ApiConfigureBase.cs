using Newtonsoft.Json;
using System.Text;

namespace GestorPacientes.Web.Controllers.ConfigureApi
{
    public abstract class ApiConfigureBase
    {
        protected readonly HttpClient httpClient;

        protected ApiConfigureBase(string baseApiUrl)
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            this.httpClient = new HttpClient(httpClientHandler);
            this.httpClient.BaseAddress = new Uri(baseApiUrl);
        }

        public async Task<T> GetApiResponseAsync<T>(string apiUrl)
        {
            using (var response = await httpClient.GetAsync(apiUrl))
            {
                response.EnsureSuccessStatusCode();
                string apiResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(apiResponse);
            }
        }

        public async Task<T> PostApiRequestAsync<T>(string apiUrl, object data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            using (var response = await httpClient.PostAsync(apiUrl, content))
            {
                response.EnsureSuccessStatusCode();
                string apiResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(apiResponse);
            }
        }
    }
}
