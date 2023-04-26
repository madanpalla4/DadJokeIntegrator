using Microsoft.Net.Http.Headers;
using System.Net.Http;
using System.Reflection.PortableExecutable;

namespace DadJokeIntegration
{
    public class HTTpService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration configuration;
        public HTTpService(HttpClient _httpClient, IConfiguration configuration)
        {
            this._httpClient = _httpClient;
            this.configuration = configuration;
        }
        public string GetData(string uri, string? serializeObject, string? routeparam, string? accessToken)
        {
            _httpClient.BaseAddress = new Uri(configuration["DadJokeKeys:Url"]);
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", configuration["DadJokeKeys:SecretKey"]);
                _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", configuration["DadJokeKeys:X-RapidAPI-Host "]);
           
            // using Microsoft.Net.Http.Headers;
            //// The GitHub API requires two headers.
            //_httpClient.DefaultRequestHeaders.Add(
            //    HeaderNames.Accept, "*/*");

            var res = _httpClient.GetAsync(uri).Result;
            return res.Content.ReadAsStringAsync().Result;

        }
    }
}
