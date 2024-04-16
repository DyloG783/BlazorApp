namespace BlazorApp1.Services
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Linq;

    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<dynamic> GetDataFromApi()
        {
            var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/todos/1");
            response.EnsureSuccessStatusCode(); // Ensure success status code

            var jsonString = await response.Content.ReadAsStringAsync();
            dynamic data = JObject.Parse(jsonString);

            return data;
        }
    }
}
