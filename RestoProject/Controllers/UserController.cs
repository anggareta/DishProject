using Microsoft.AspNetCore.Mvc;
using RestoProject.Services.UserService;
using RestoProject.Shared.DTOs;

namespace RestoProject.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
      _userService = userService;
    }

    [HttpPost]
    public async Task<ActionResult<ResObj>> login(UserLogin userpass)
    {
      return Ok(await _userService.Login(userpass.Username, userpass.Password));
    }
  }

}
