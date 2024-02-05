using RestoProject.Shared.DTOs;

namespace RestoProject.Client.Services.UserService
{
  public interface IUserService
  {
    Task<ResObj> Login(string username, string password);
  }
}
