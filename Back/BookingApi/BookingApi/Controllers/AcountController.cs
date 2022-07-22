using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BookingApi.DTO;
using BookingApi.Models;
using BookingApi.database;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace BookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public AcountController(UserManager<User> userManager,IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
           
        }
        [HttpPost("Register")]
        public async Task<ActionResult> Registeration(RegisterUserDto newAcount)

        {
            User user = new User();
            user.FirstName = newAcount.FirstName;
            user.LastName = newAcount.LastName;
            user.UserName = newAcount.UserName;
            user.Email = newAcount.Email;
            user.city = newAcount.city;
            user.country = newAcount.country;
            



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
                _userManager.AddToRoleAsync(user,"User");

                return Ok("Acount Add Success");

            }
            else
            {
                return BadRequest("Data is not valid");
            }


        }
       // ..............................Login....................
        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginDto Userlogin)

        {

            if (ModelState.IsValid == true)
            {
                User user = await _userManager.FindByNameAsync(Userlogin.UserName);
                if (user != null)
                {
                    
                    if (await _userManager.CheckPasswordAsync(user,Userlogin.Password)==true)
                    {
                        var claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.Name,user.UserName));
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                        var roles=await _userManager.GetRolesAsync(user);
                        foreach(var role in roles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role,role));

                        }
                        //Jti "Identifier Token"
                        claims.Add(new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()));
                        // token
                        SecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecrurityKey"]));
                        SigningCredentials signingCredentials = new SigningCredentials(
                               key, SecurityAlgorithms.HmacSha256

                            );
                        var token = new JwtSecurityToken(
                            audience: _configuration["JWT:ValiedAudience"],
                            issuer: _configuration["JWT:ValidIssuer"],
                           
                            claims:claims,
                             expires: DateTime.Now.AddHours(12),
                            signingCredentials: signingCredentials
                            );

                        return Ok(
                            new
                            {
                                token = new JwtSecurityTokenHandler().WriteToken(token),
                                expires =token.ValidTo
                            }) ;
                    }
                    else
                    {

                        return Unauthorized();
                    }

                }
                else
                {
                    return BadRequest("Username or password is not valid");
                }

            }
            else
            {
                return Problem("Data is not valid");
            }

        }
       

    }
}
