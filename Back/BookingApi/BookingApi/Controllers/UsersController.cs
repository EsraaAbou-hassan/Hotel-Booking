using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using BookingApi.Models;
using BookingApi.database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly Bookingdb _context;

        public UsersController(Bookingdb context)
        {
            _context = context;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdentityUser>>> GetUsers()
        {
            if (_context.Users== null)
            {
                return NotFound();
            }
            
              return await _context.Users.ToListAsync();  
        }

    }
}
