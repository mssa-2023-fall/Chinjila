using MakeRESTCall;
using System.Net.Http.Headers;
using System.Text.Json;

using HttpClient client = new();

client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(
    new MediaTypeWithQualityHeaderValue("application/vnd.github+json"));

client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

var repositories = await ProcessRepositoriesAsync(client);

foreach (var repo in repositories.OrderByDescending(r=>r.LastPushUtc).Take(5))
{
    Console.WriteLine($"Name: {repo.Name}");
    Console.WriteLine($"Homepage: {repo.Homepage}");
    Console.WriteLine($"GitHub: {repo.GitHubHomeUrl}");
    Console.WriteLine($"Description: {repo.Description}");
    Console.WriteLine($"Watchers: {repo.Watchers:#,0}");
    Console.WriteLine($"{repo.LastPush}");
    Console.WriteLine();
}

//Try API Ninja
HttpClient ninjaClient = new();
ninjaClient.DefaultRequestHeaders.Add("X-Api-Key", Environment.GetEnvironmentVariable("apikey"));

string country = "US";
string city = "New York";

string apiEndpoint = $"https://api.api-ninjas.com/v1/airports?country={country}&city={city}";
await using Stream stream =  await ninjaClient.GetStreamAsync(apiEndpoint);
var airports =  await JsonSerializer.DeserializeAsync<List<Airport>>(stream);

foreach (var item in airports)
{
    Console.WriteLine(item.name);
}

static async Task<List<Repository>> ProcessRepositoriesAsync(HttpClient client)
{
    await using Stream stream = await client.GetStreamAsync("https://api.github.com/orgs/mssa-2023-fall/repos");
    var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(stream);

    return repositories ?? new();
}