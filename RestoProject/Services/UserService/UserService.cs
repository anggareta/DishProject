using Azure;
using Microsoft.EntityFrameworkCore;
using RestoProject.Data;
using RestoProject.Shared.DTOs;
using RestoProject.Shared.Entities;

namespace RestoProject.Services.UserService
{
  public class UserService : IUserService
  {
    private readonly DataContext _context;

    public UserService(DataContext context)
    {
      _context = context;
    }

    public async Task<ResObj> Login(string username, string password)
    {
      string enPass = Utility.sha256(password);
      ResObj resObj = new ResObj();

      Users users = await _context.Users.Where(u => u.Username == username && u.Password == enPass).FirstOrDefaultAsync();

      if (users is not null)
      {
        resObj.statusId = 0;
        resObj.error = "";
        resObj.message = users.Username;
      }
      else
      {
        resObj.statusId = 1;
        resObj.error = "user not found";
        resObj.message = "";
      }

      return resObj;
    }

  }
}
