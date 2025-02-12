using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using MMADatabase;
using MusicMemoryArchiveBackend;

namespace Aspapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly MusicMemoryArchiveContext _db;
        private UserManager<UserClass> _userManager;
      
        public SeedController(MusicMemoryArchiveContext db,IWebHostEnvironment environment,
            UserManager<UserClass> userManager)
        {
            _db = db;
            _userManager = userManager;
           
        }


        [HttpPost("RegisterUser")]
        public async Task<IActionResult> UserRegistrationAsync(UserRegistration newUser)
        {
            (string name, string email, string password) = (newUser.UserName, newUser.Email, newUser.Password);
            UserClass user = new()
            {
                UserName = name,
                Email = email,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            if (await _userManager.FindByNameAsync(name) is not null)
            {
                user.UserName = name;

            }
            _ = await _userManager.CreateAsync(user, password)
                ?? throw new InvalidOperationException();

            user.EmailConfirmed = true;
            user.LockoutEnabled = false;
            await _db.SaveChangesAsync();
            return Ok();
        }

    }
}
