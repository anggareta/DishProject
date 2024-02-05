using Blazored.LocalStorage;

namespace RestoProject.Client.Services.StatsService
{
  public class StatsService : IStatsService
  {
    private readonly HttpClient _http;
    private readonly ILocalStorageService _localStorage;

    public StatsService(HttpClient http, ILocalStorageService localStorage)
    {
      _http = http;
      _localStorage = localStorage;
    }

    public async Task GetVisits()
    {
      int visits = int.Parse(await _http.GetStringAsync("api/Stats"));
      Console.WriteLine($"Visits: {visits}");
    }

    public async Task IncrementVisits()
    {
      DateTime? lastVisit = await _localStorage.GetItemAsync<DateTime?>("lastVisit");
      if (lastVisit == null || (DateTime)lastVisit < DateTime.Now)
      {
        await _localStorage.SetItemAsync("lastVisit", DateTime.Now);
        await _http.PostAsync("api/Stats", null);
      }
    }
  }
}
