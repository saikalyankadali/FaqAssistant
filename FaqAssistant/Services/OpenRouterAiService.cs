using System.Net.Http.Json;

public class OpenRouterAiService
{
    private readonly HttpClient _http;

    public OpenRouterAiService(HttpClient http)
    {
        _http = http;
        _http.DefaultRequestHeaders.Add("Authorization", "Bearer YOUR_OPENROUTER_KEY");
    }

    public async Task<string> SuggestAnswer(string question)
    {
        var req = new
        {
            model = "mistral-7b-instruct",
            prompt = $"Provide a helpful FAQ answer for: {question}",
            max_tokens = 200
        };

        var response = await _http.PostAsJsonAsync("https://openrouter.ai/api/v1/chat/completions", req);
        var json = await response.Content.ReadFromJsonAsync<dynamic>();

        return (string)json.choices[0].message.content;
    }
}
