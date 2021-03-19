using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TestApp.Models;

namespace TestApp.Service
{
    public class ApiService
    {
        public async Task<ApiModel> GetData()
        {
            string body = string.Empty;
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://community-open-weather-map.p.rapidapi.com/forecast?q=san%20francisco%2Cus"),
                Headers =
                {
                    { "x-rapidapi-key", "f470cfa298msh7f3f7ffc30a8a31p1a33f9jsn6b2d9ffbdaa7" },
                    { "x-rapidapi-host", "community-open-weather-map.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                body = await response.Content.ReadAsStringAsync();
            }

            ApiModel myDeserializedApiModel = JsonConvert.DeserializeObject<ApiModel>(body);

            return myDeserializedApiModel;
        }
    }
}
