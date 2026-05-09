using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StuentMangementSys.Helpers;
using StuentMangementSys.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StuentMangementSys.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtHelper _jwtHelper;

        public AuthController(JwtHelper jwtHelper)
        {
            _jwtHelper = jwtHelper;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginModel model)
        {
            if (model.Username == "admin"
                && model.Password == "admin123")
            {
                var token =
                    _jwtHelper.GenerateToken(model.Username);

                return Ok(new ApiResponse<string>(
                    true,
                    "Login successful",
                    token));
            }

            return Unauthorized(
                new ApiResponse<string>(
                    false,
                    "Invalid username or password",
                    null));
        }
    }
}
