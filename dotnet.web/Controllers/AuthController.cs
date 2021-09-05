using System;
using dotnet.data.Models;
using dotnet.service.AuthService;
using dotnet.service.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dotnet.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly ILogger<AuthController> _logger;
        public readonly IAuthService _authService;
        public readonly JwtService _jwtService;
        public AuthController(ILogger<AuthController> logger, IAuthService authService, JwtService jwtService)
        {
            _logger = logger;
            _authService = authService;
            _jwtService = jwtService;
        }
        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody] UserRegister user)
        {
            var res = _authService.Register(user);
            return Ok(res);
        }
        [HttpPost("login")]
        public ActionResult Login([FromBody] UserLogin credential)
        {
            var res = _authService.Login(credential);
            var token = _jwtService.Generate(res.Data.Id.ToString());
            Response.Cookies.Append("session", token, new CookieOptions
            {
                HttpOnly = true
            });
            return Ok(res);
        }
        [HttpPost("logout")]
        public ActionResult LogOut()
        {
            Response.Cookies.Delete("session");
            return Ok("logged Out!");
        }
    }
}
