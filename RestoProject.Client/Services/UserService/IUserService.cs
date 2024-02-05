using RestoProject.Shared.DTOs;

namespace RestoProject.Client.Services.UserService
{
  public interface IUserService
  {
    event Action OnChange;
    Task<ResObj> Login(string username, string password);
  }
}
