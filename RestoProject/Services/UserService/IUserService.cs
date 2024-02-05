using RestoProject.Shared.DTOs;

namespace RestoProject.Services.UserService
{
  public interface IUserService
  {
    Task<ResObj> Login(string username, string password);
  }
}
