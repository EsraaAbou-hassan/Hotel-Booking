using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BookingApi.Models;
using BookingApi.database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BookingApi.ViewModel;

namespace BookingApi.Services
{
    public class RoleServices
    {
        RoleManager<IdentityRole> _roleManager;
        UserManager<User> _userManager;
        Bookingdb _context;
        public RoleServices() { }

        public RoleServices( RoleManager<IdentityRole> roleManager, UserManager<User> userManager, Bookingdb context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context; 
        }
        public async void CreatedRole_User()
        {

            
        //        List<Role> Rolrs= _context.Roles.ToList();
        //    //List<IdentityRole> Roles = _context.Roles.ToList();
        //    //if (Roles.FindAll(e => e.Name == RoleName.Admin) == null)
        //    if (_roleManager.RoleExistsAsync(RoleName.Admin)==null)
        //    {
        //        IdentityRole roleManager = new IdentityRole();

        //        roleManager.Name = RoleName.Admin;
        //        await _roleManager.CreateAsync(roleManager);

        //        User user = new User();
        //        user.UserName = "admin";
        //        user.Email = "admin@gmail.com";

        //        user.country = "Egypt";
        //        user.city = "mansoura";

        //        user.visaNumber = 123456;
        //        user.visapassword = 123467;

        //        ;

                
               
        //        string userpass = "123456";
        //        var checkuser = _userManager.CreateAsync(user, userpass);

        //        if (checkuser.Result.Succeeded)
        //        {
        //            _userManager.AddToRoleAsync(user, RoleName.Admin);
        //        }


        //    }


        //    if (_roleManager.RoleExistsAsync(RoleName.User) == null)

        //        //if (Roles.FindAll(e => e.Name == RoleName.User) == null)
        //    {
        //        IdentityRole roleUser = new IdentityRole();

        //        roleUser.Name = RoleName.User;
        //        await _roleManager.CreateAsync(roleUser);


        //    }




   
           




        }



    }

    }

