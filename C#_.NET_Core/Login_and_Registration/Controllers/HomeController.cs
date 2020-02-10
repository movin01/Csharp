using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Login_and_Registration.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;


namespace Login_and_Registration.Controllers
{
    public class HomeController : Controller
    {
        // private int? UserSession
        // {
        //     get {return HttpContext.Session.GetInt32("UserId");}
        //     set {HttpContext.Session.SetInt32("UserId" , (int) value);}
        // }
        private MyContext dbContext;
        // here we can "inject" our context service into the constructor
        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            HttpContext.Session.Clear();
            return View();
        }

        // Inside HomeController
        [HttpPost("register")]
        public IActionResult Register(User NewUser)
        {
            // If a User exists with provided email
            if (dbContext.User.Any(u => u.Email == NewUser.Email))
            {
                // Manually add a ModelState error to the Email field, with provided
                // error message
                ModelState.AddModelError("Email", "Email already in use!");
                // You may consider returning to the View at this point
               return View("Index", NewUser);
            }

            // Check initial ModelState
            if (ModelState.IsValid)
            {
                // Initializing a PasswordHasher object, providing our User class as its
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                NewUser.Password = Hasher.HashPassword(NewUser, NewUser.Password);
                // We can take the User object created from a form submission
                // And pass this object to the .Add() method
                dbContext.Add(NewUser);
                // OR dbContext.Users.Add(newUser);
                dbContext.SaveChanges();
                var userindb = dbContext.User.FirstOrDefault(u => u.Email == NewUser.Email);
                HttpContext.Session.SetInt32("SessionUserID", userindb.UserId);
                return RedirectToAction("Success");
            }
            else
            {
                return View("Index", NewUser);
            }
        }

        [HttpGet]
        [Route("Login")]
        public IActionResult Loginpage()
        {
            return View("Login");
        }

        [HttpPost("Login")]
        public IActionResult Login(User user)
        {
            var userindb = dbContext.User.FirstOrDefault(u => u.Email == user.Email);
            if (userindb == null)
            {
                return View("Login");
            }
            HttpContext.Session.SetInt32("SessionUserID", userindb.UserId);
            return RedirectToAction("Success");
        }

        [HttpGet("Success")]
        public IActionResult Success()
        {
            if (HttpContext.Session.GetInt32("SessionUserID") == null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

    }
}

