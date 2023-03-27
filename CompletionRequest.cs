using System.Text.Json.Serialization;

namespace AskApp;

public class CompletionRequest
{
        [JsonPropertyName("model")]
        public string Model { get; set; }

        [JsonPropertyName("prompt")]
        public string Prompt { get; set; }

        [JsonPropertyName("max_tokens")]
        public int MaxTokens { get; set; }

        [JsonPropertyName("temperature")]
        public int Temperature { get; set; }

        public static CompletionRequest From(string prompt) 
        {
            return new CompletionRequest 
            {
                MaxTokens = 100,
                Model = "text-davinci-001",
                Temperature = 1,
                Prompt = prompt
            };
        }
}