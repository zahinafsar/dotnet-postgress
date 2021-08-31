using System;
using dotnet.service.UserService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dotnet.web.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly ILogger<UserController> _logger;
        public readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet("/api/users")]
        public ActionResult GetUsers()
        {
            _logger.LogInformation("Getting user");
            var res = _userService.GetAllUsers();
            return Ok(res);
        }
    }
}