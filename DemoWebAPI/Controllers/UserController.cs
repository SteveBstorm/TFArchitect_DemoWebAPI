using BLL_CorrectifLabo.Interface;
using BLL_CorrectifLabo.Models;
using DemoWebAPI.DTOs;
using DemoWebAPI.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService _userService, TokenManager _tokenManager) : ControllerBase
    {
        [HttpPost("Register")]
        public IActionResult Register(UserRegisterForm form)
        {
            _userService.Register(form.ToBLL(), form.Password);
            return Ok();
        }

        [HttpPost("Login")]
        public IActionResult Login(UserLoginForm form)
        {
            try
            {
                User currentUser = _userService.Login(form.Email, form.Password);
                string token = _tokenManager.GenerateToken(currentUser);
                return Ok(token);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
