using BLL_CorrectifLabo.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService _userService) : ControllerBase
    {

    }
}
