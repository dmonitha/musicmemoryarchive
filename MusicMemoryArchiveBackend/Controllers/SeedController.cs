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

        [HttpPost("AdminUser")]
        public async Task<IActionResult> ImportUsersAsync() 
        {
            (string name, string email) = ("admin", "admin@gmail.com");
            UserClass user = new()
            {
                UserName = name,
                Email = email,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            if(await _userManager.FindByNameAsync(name) is not null)
            {
                user.UserName = "AdminUser";

            }
            _ = await _userManager.CreateAsync(user, "Password@123")
                ?? throw new InvalidOperationException();
           
                
            user.EmailConfirmed = true;
            user.LockoutEnabled = false;
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> UserRegistrationAsync(UserRegistration newUser)
        {
            (string name, string email, string password) = (newUser.UserName, newUser.Email, newUser.Password);
            Console.WriteLine("not sure but lets see");
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
