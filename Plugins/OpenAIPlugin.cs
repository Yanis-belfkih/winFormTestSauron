using winFormTestSauron.Interfaces;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace winFormTestSauron.Plugins
{
    class OpenAIPlugin : IPlugin
    {
        public string Name { get; } = "OpenAIPlugin";
        private HttpClient _httpClient = new HttpClient();
        private string _apiKey = "";
        const string ApiEndpoint = "https://api.groq.com/openai/v1/chat/completions";

        public void Initialize()
        {
            if (string.IsNullOrEmpty(_apiKey)) 
            {
                throw new InvalidOperationException("La clé API OpenAI n'est pas définie.");
            }

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
        }

        public async Task<string> ExecuteCallAsync(string inputMessage)
        {
            var body = new
            {
                model = "openai/gpt-oss-120b",
                messages = new[]
              {
          new { role = "system", content = "Tu es un assistant IA français." },
          new { role = "user", content = inputMessage }
        },
                temperature = 0.7, 
            };
            var json = JsonSerializer.Serialize(body);
            
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(ApiEndpoint, content);
            response.EnsureSuccessStatusCode();

            var doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync());

            return doc.RootElement
              .GetProperty("choices")[0]
              .GetProperty("message")
              .GetProperty("content")
              .GetString() ?? "Pas de réponse.";
        }
    }
}