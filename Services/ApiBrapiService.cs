using Newtonsoft.Json;
using stockz_bucketz_api.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace stockz_bucketz_api.Services
{
    public class ApiBrapiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _token;

        public ApiBrapiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _token = Environment.GetEnvironmentVariable("tokenBrapi", EnvironmentVariableTarget.Machine);
        }

        public async Task<List<StockBrapi>> Get()
        {
            var url = $"https://brapi.dev/api/quote/list?token={_token}?search=ibo";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to retrieve data from BrAPI.");
            }

            var data = await response.Content.ReadAsStringAsync();
            var responseBrapiObj = JsonConvert.DeserializeObject<ResponseBrapi>(data);
            var stocks = responseBrapiObj?.Stocks ?? new List<StockBrapi>();
            return stocks;
        }
    }
}
