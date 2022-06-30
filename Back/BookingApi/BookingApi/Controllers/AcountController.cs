using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BookingApi.ViewModel;
using BookingApi.Models;
using BookingApi.database;
using Microsoft.EntityFrameworkCore;

namespace BookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        public readonly SignInManager<IdentityUser> _signInManager;
        public AcountController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }




        [HttpPost("Register")]
        public async Task<ActionResult> Registeration(RegisterAcountViewModel newAccount)

        {
            User user = new User();
            user.UserName = newAccount.UserName;
            user.Email = newAccount.Email;
            user.city = newAccount.city;
            user.country = newAccount.country;
            user.img = newAccount.img;



            if (ModelState.IsValid == true)
            {
                IdentityResult result = await _userManager.CreateAsync(user, newAccount.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                return Ok();

            }
            else
            {
                return Problem("Data is not valid");
            }


        }
        //..............................Login....................
        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginViewModel Userlogin,string ReturnUrl= "~/Hotels/GetHotel")

        {

            if (ModelState.IsValid == true)
            {
                IdentityUser user = await _userManager.FindByNameAsync(Userlogin.UserName);
                if (user != null)
                {
                    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, Userlogin.Password, Userlogin.IsPersisite, false);
                    if (result.Succeeded)
                    {
                        return Ok();
                    }
                    else
                    {

                        ModelState.AddModelError("", " Username or password is not valid");
                        return Problem("Username or password is not validPassword ");
                    }

                }
                else
                {
                    ModelState.AddModelError("", "Invalid Username or password");
                    return Problem("Username or password is not validPassword ");
                }

            }
            else
            {
                return Problem("Data is not valid");
            }

        }
        //..............................Sign out....................
        [HttpGet("LogOut")]
        public async Task<ActionResult>LogOut()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }
    }
}
