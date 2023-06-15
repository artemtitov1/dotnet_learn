using Dadata;
using System.Net.Http.Headers;

namespace INN_client
{
    public class DadataClient
    {
        string token = "";
        string secret = "";

        public DadataClient(string token, string secret = "") 
        {
            token = token;
            secret = secret;
        }
        public DadataClient() { }
        public async Task connectViaDadataApi()
        {
            Console.Write("Введите ИНН или ОГРН организации: ");
            var INN = Console.ReadLine();
            var api = new SuggestClientAsync(token);
            var result = await api.FindParty(INN);
            if (result != null)
                foreach (var item in result.suggestions)
                    Console.WriteLine(result.suggestions[0].value);
        }

        public async Task connectViaHttpClient()
        {
            Console.Write("Введите ИНН или ОГРН организации: ");
            var inn = Console.ReadLine();

            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Token {token}");

            string requestBody = $"{{\"query\": \"{inn}\", \"count\": 1}}";
            var content = new StringContent(requestBody);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await httpClient.PostAsync("https://suggestions.dadata.ru/suggestions/api/4_1/rs/findById/bank", content);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
            }
            else
            {
                Console.WriteLine("Status code: " + response.StatusCode);
            }
        }
    }
}
