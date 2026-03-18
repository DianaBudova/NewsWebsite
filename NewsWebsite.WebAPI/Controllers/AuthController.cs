using Microsoft.AspNetCore.Mvc;
using NewsWebsite.WebAPI.Security;

namespace NewsWebsite.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserAuth _userAuth;

        public AuthController(UserAuth userAuth)
        {
            _userAuth = userAuth;
        }

        [HttpPost("login")]
        public IActionResult Login(string username, string password)
        {
            if (_userAuth.Login(username, password))
            {
                return Ok("Login successful.");
            }

            return Unauthorized("Invalid username or password.");
        }
    }
}