using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Threading.Tasks;
using dotnet.data.Models;
using dotnet.service.Helper;
using dotnet.service.UserService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace dotnet.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly ILogger<UserController> _logger;
        public readonly IUserService _userService;
        public readonly JwtService _jwtService;
        public readonly IHttpClientFactory _httpClient;
        public UserController(ILogger<UserController> logger, IUserService userService, JwtService jwtService, IHttpClientFactory httpClient)
        {
            _logger = logger;
            _userService = userService;
            _jwtService = jwtService;
            _httpClient = httpClient;
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
        [HttpPost("{id}/profile")]
        public ActionResult AddProfile(int id, [FromBody] Profile profile)
        {
            var res = _userService.AddProfile(id, profile);
            return Ok(res);
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
        [HttpGet("weather")]
        public async Task<ActionResult> GetWeather(int id)
        {
            var http = _httpClient.CreateClient();
            var response = await http.GetAsync("https://jsonplaceholder.typicode.com/todos");
            var contentAsString = await response.Content.ReadAsStringAsync();
            HttpUser[] content = JsonConvert.DeserializeObject<HttpUser[]>(contentAsString);
            return Ok(content);
        }
    }
}