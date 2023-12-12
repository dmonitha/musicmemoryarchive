using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using MMADatabase;

namespace Aspapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<UserClass> _userManager;
        private readonly JwtHandler _jwtHandler;
        
        public AdminController(UserManager<UserClass> userManager, JwtHandler jwtHandler)
        {
            _userManager = userManager;
            _jwtHandler = jwtHandler;
        }
        [HttpPost]
        public async Task<IActionResult> Login(Loginrequest loginRequest)
        {
            UserClass? user = await _userManager.FindByNameAsync(loginRequest.UserName);
            if (user == null) {
                return Unauthorized("Bad username");

            }
            bool success = await _userManager.CheckPasswordAsync(user,loginRequest.Password);
            if(!success) {
                return Unauthorized("Wrong Password");
            }
           JwtSecurityToken secToken = await _jwtHandler.GetTokenAsync(user);
            string? jwtstr = new JwtSecurityTokenHandler().WriteToken(secToken);
            return Ok(new LoginResult
            {
                Success = true,
                Message = "It works!",
                Token = jwtstr
            });
        }
    }
}
