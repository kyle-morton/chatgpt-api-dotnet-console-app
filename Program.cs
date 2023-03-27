using System.Text;
using System.Text.Json;
using AskApp;

if (args.Length == 0)
{
    Console.WriteLine("Arguments are required to run this application. Please close and try again.");
    Console.ReadLine();
    return;
}

var config = AppSettingsReader.GetConfiguation();

var baseUrl = config["OpenAI:BaseUrl"];
var apiKey = config["OpenAI:ApiKey"];

using var httpClient = new HttpClient();
httpClient.DefaultRequestHeaders.Add("authorization", $"Bearer {apiKey}");

var request = CompletionRequest.From(args[0]);

var content = new StringContent(JsonSerializer.Serialize(request),Encoding.UTF8, "application/json");

var response = await httpClient.PostAsync($"{baseUrl}/v1/completions", content);
var responseStr = await response.Content.ReadAsStringAsync();

try
{
    var dynamicData = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(responseStr);
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"---> API Response is: {dynamicData.choices[0].text}");
    Console.ResetColor();
}
catch (System.Exception ex)
{
    Console.WriteLine("Exception on deserialize", ex);
}
