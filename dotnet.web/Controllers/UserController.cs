using System;
using System.IdentityModel.Tokens.Jwt;
using dotnet.data.Models;
using dotnet.service.Helper;
using dotnet.service.UserService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dotnet.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly ILogger<UserController> _logger;
        public readonly IUserService _userService;
        public readonly JwtService _jwtService;
        public UserController(ILogger<UserController> logger, IUserService userService, JwtService jwtService)
        {
            _logger = logger;
            _userService = userService;
            _jwtService = jwtService;
        }
        [HttpGet]
        public ActionResult GetAllUsers()
        {
            // _logger.LogInformation("Getting all users...");
            var res = _userService.GetAllUsers();
            return Ok(res);
        }
        [HttpGet("{id}")]
        public ActionResult GetSignleUser(int id)
        {
            // _logger.LogInformation("Getting single user...");
            var res = _userService.GetUser(id);
            return Ok(res);
        }
        [HttpPost]
        public ActionResult CreateUser([FromBody] User user)
        {
            // _logger.LogInformation("Create single user...");
            try
            {
                var jwtToken = Request.Cookies["session"];
                _jwtService.Verify(jwtToken);
                var res = _userService.CreateUser(user);
                return Ok(res);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            // _logger.LogInformation("Create single user...");
            try
            {
                var jwtToken = Request.Cookies["session"];
                _jwtService.Verify(jwtToken);
                var res = _userService.DeleteUser(id);
                return Ok(res);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }
    }
}