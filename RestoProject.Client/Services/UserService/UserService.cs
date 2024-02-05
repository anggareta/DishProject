using RestoProject.Shared.DTOs;
using System.Net.Http.Json;
using Blazored.Toast.Services;

namespace RestoProject.Client.Services.UserService
{
  public class UserService : IUserService
  {
    private readonly HttpClient _http;
    private readonly IToastService _toastService;

    public UserService(HttpClient http, IToastService toastService)
    {
      _http = http;
      _toastService = toastService;
    }

    public async Task<ResObj> Login(string username, string password)
    {
      UserLogin userLogin = new UserLogin();
      userLogin.Username = username;
      userLogin.Password = password;
      HttpResponseMessage res = await _http.PostAsJsonAsync("api/User", userLogin);
      ResObj obj = res.Content.ReadFromJsonAsync<ResObj>().Result;

      if (obj.statusId == 0)
      {
        _toastService.ShowSuccess("Login successfully", null);
      }
      else
      {
        _toastService.ShowError("Login failed", null);
      }

      return obj;
    }

  }
}
