using System;
using dotnet.data.Models;
using dotnet.service.AuthService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dotnet.web.Controllers
{
    [Route("api/auth/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly ILogger<AuthController> _logger;
        public readonly IAuthService _authService;
        public AuthController(ILogger<AuthController> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
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
            return Ok(res);
        }
    }
}
