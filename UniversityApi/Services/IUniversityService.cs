using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using UniversityApi.Config;
using UniversityApi.Models;

namespace UniversityApi.Services
{
    public interface IUniversityService 
    {
        Task<IEnumerable<UniversityModel>> SearchAsync(string country, string name);
    }

    public class UniversityService : IUniversityService
    {
        private readonly UniversityConfig _config;

        private static readonly HttpClient _httpClient = new HttpClient();

        public UniversityService(IOptions<UniversityConfig> config)
        {
            _config = config.Value;            
        }

        public async Task<IEnumerable<UniversityModel>> SearchAsync(string country, string name)
        {
            var result = new List<UniversityModel>();

            var url = $"{_config.ApiBaseUrl}?country={country}&name={name}";

            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<UniversityModel>>(responseContent);
            }

            return result;
        }
    }
}