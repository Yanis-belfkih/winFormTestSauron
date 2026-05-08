using winFormTestSauron.Interfaces;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace winFormTestSauron.Plugins
{
    class OpenAIPlugin : IPlugin
    {
        // FIX 1: "{ get; }" au lieu de "=" pour satisfaire l'interface
        public string Name { get; } = "OpenAIPlugin";
        private HttpClient _httpClient = new HttpClient();
        // FIX 2: pas "readonly" car on l'assigne dans Initialize()
        private string _apiKey = "";

        public void Initialize()
        {
            // Si une clé est fournie via la variable d'environnement, l'utiliser (trim pour retirer espaces/retours)
            var env = Environment.GetEnvironmentVariable("OPENAI_API_KEY")?.Trim();
            if (!string.IsNullOrEmpty(env))
            {
                _apiKey = env;
            }

            // Si après cela _apiKey est vide, on signale l'erreur
            if (string.IsNullOrEmpty(_apiKey))
            {
                throw new Exception("Clé API OPENAI_API_KEY manquante !");
            }

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
        }

        // FIX 3: "async Task<string>" au lieu de "string" pour pouvoir utiliser await
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
                temperature = 0.7, // Permet de rendre la réponse un peu plus aléatoire, moins robotique et plus créative
            };
            var json = JsonSerializer.Serialize(body);
            // FIX 4: point-virgule manquant à la fin de cette ligne
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // FIX 5: "openai.com" pas "openai.comm"
            var response = await _httpClient.PostAsync("https://api.groq.com/openai/v1/chat/completions", content);
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