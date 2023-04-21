using CeeStore.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CeeStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public UsersController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        [HttpGet("get-all-users")]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IEnumerable<AppUser>> GetAllUsers()
        {
            return await _userManager.Users.ToListAsync();
        }

    }
}
