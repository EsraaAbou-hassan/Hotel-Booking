using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using BookingApi.Models;
using BookingApi.database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BookingApi.DTO;

namespace BookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly Bookingdb _context;
        private readonly UserManager<User> _userManager;
       

        
        public UsersController(Bookingdb context, UserManager<User> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdentityUser>>> GetUsers()
        {
            if (_context.Users== null)
            {
                return NotFound();
            }
            
              return await _context.Users.ToListAsync();  
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(string id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        // POST: api/Users
        [HttpPost("Add")]
        public async Task<ActionResult<Room>> AddUser(RegisterUserDto newAcount)
        {
            User user = new User();
            user.FirstName=newAcount.FirstName;
            user.LastName=newAcount.LastName;
            user.UserName = newAcount.UserName;
            user.Email = newAcount.Email;
            user.city = newAcount.city;
            user.country = newAcount.country;
            user.img = newAcount.img;



            if (ModelState.IsValid)
            {
                IdentityResult result = await _userManager.CreateAsync(user, newAcount.Password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);


                    }
                    return BadRequest(ModelState);
                }
                return Ok("Acount Add Success");

            }
            else
            {
                return BadRequest("Data is not valid");
            }


        }
        // PUT: api/Users/5
        [HttpPut("Update/{id}")]
        
        public async Task<IActionResult> UpdateUser(string id, RegisterUserDto olddata)
        {
            User user = await _context.Users.FindAsync(id);
            user.LastName = olddata.LastName != "string" ? olddata.LastName: user.LastName;
            user.FirstName = olddata.FirstName != "string" ? olddata.FirstName : user.FirstName;
            user.UserName = olddata.UserName!="string"?olddata.UserName: user.UserName;
            user.Email = olddata.Email != "string" ? olddata.Email : user.Email;
            user.city = olddata.city != "string" ? olddata.city : user.city;
            user.country=olddata.country != "string" ? olddata.country : user.country;
            user.img=olddata.img != "string" ? olddata.img: user.img;
            

            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok("data Updated Successfully");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        // DELETE: api/Rooms/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
           
                if (_context.Users == null)
                {
                    return NotFound();
                }
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    _context.Users.Remove(user);
                    await _context.SaveChangesAsync();
                    return Ok("data Deleted Successfully"); 
                }

               

                return NoContent();
            

        }


        private bool UserExists(string id)
        {
            return (_context.Users?.Any(e => e.Id== id)).GetValueOrDefault();
        }
    }
}
