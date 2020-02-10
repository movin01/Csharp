using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using beltexam2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace beltexam2.Controllers
{
    public class HomeController : Controller
    {

        private MyContext dbContext;
        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }


        // Inside HomeController
        [HttpPost("register")]
        public IActionResult Register(User NewUser)
        {
            if (dbContext.Users.Any(u => u.Email == NewUser.Email))
            {
                // Manually add a ModelState error to the Email field, with provided
                // error message
                ModelState.AddModelError("Email", "Email already in use!");
                // You may consider returning to the View at this point
                return View("Index", NewUser);
            }
            // If a User exists with provided email

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
                var userindb = dbContext.Users.FirstOrDefault(u => u.Email == NewUser.Email);
                HttpContext.Session.SetInt32("SessionUserID", NewUser.UserId);
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View("Index", NewUser);
            }
        }

        [HttpPost("Login")]
        public IActionResult Login(User user)
        {
              if (ModelState.IsValid)
              {
            var userindb = dbContext.Users.FirstOrDefault(u => u.Email == user.Email);
            if (userindb == null)
            {
                return View("Index", user);
            }
            var Hasher = new PasswordHasher<User>();
            var result = Hasher.VerifyHashedPassword(user, userindb.Password, user.Password);
            if (result != 0)
            {
                HttpContext.Session.SetInt32("SessionUserID", userindb.UserId);
                return RedirectToAction("Dashboard");
            }
            return View("Index", user);
              }
        return View("Index", user);
        }
        // *********************************************************************************************^^^LOGIN REG
        [HttpGet("Dashboard")]
        public IActionResult Dashboard(int HobbyId)
        {
            if (HttpContext.Session.GetInt32("SessionUserID") == null)
            {
                return RedirectToAction("Index");
            }
            WrapperViewModel AllTheThings = new WrapperViewModel();
            Hobby new_Hobby = new Hobby();
            AllTheThings.OneHobby = new_Hobby;
            AllTheThings.OneHobby.HobbyName = "";
            AllTheThings.LoggedInUser = dbContext.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("SessionUserID"));
            AllTheThings.AllHobbies = dbContext.Hobbies.Include(w => w.Responses).ToList();
            return View(AllTheThings);
        }

        [HttpGet]
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }



        [HttpGet]
        [Route("CreateHobbypage")]
        public IActionResult CreateHobbypage()
        {
            return View("CreateHobbypage");
        }

        [HttpGet("{HobbyId}")]
        [Route("HobbyDescriptionpage")]
        public IActionResult HobbyDescriptionpage(int hobbyId)
        {
            if (HttpContext.Session.GetInt32("SessionUserID") == null)
            {
                return RedirectToAction("Index");
            }
            WrapperViewModel AllThings = new WrapperViewModel();
            AllThings.OneHobby = dbContext.Hobbies.FirstOrDefault(a => a.HobbyId == hobbyId);
            AllThings.AllHobbies = dbContext.Hobbies.Include(c => c.Responses).ToList();
            AllThings.AllUsers = dbContext.Users.Include(b => b.Participants).ToList();
            return View("HobbyDescriptionpage", AllThings);
        }



        // ****************************************************************^^^ ROUTES TO PAGES
        // ****************************************************************CREATE LOGIC


        [HttpPost("CreateHobby")]
        public IActionResult CreateHobby(Hobby newHobby)
        {
            if (HttpContext.Session.GetInt32("SessionUserID") == null)
            {
                return RedirectToAction("Index");
            }
            if (ModelState.IsValid)
            {
                // create foriegn key to something else
                newHobby.CreatorId = (int)HttpContext.Session.GetInt32("SessionUserID");
                // do somethng!  maybe insert into db?  then we will redirect
                dbContext.Add(newHobby);
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard", newHobby);
            }
            return View("CreateHobbypage");
        }

        // *********************************************************************CREAT LOGIC END**********************************
        // *****************************************************************Add To Hobbies = Likes = RSVP*******************************


        [HttpGet("addtohobbys/{HobbyId}")]
        public IActionResult addtohobbys(int hobbyId)
        {
            if (HttpContext.Session.GetInt32("SessionUserID") == null)
            {
                return RedirectToAction("Index");
            }
            WrapperViewModel AllThings = new WrapperViewModel();
            AllThings.OneAssociation = new Association();
            AllThings.OneAssociation.UserId = (int)HttpContext.Session.GetInt32("SessionUserID");
            AllThings.OneAssociation.HobbyId = hobbyId;
            Hobby OneHobby = dbContext.Hobbies.Include(g => g.Responses).FirstOrDefault(r => r.HobbyId == hobbyId);
            dbContext.Add(AllThings.OneAssociation);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }



        // *****************************************************************Add To Hobbies = Likes = RSVP LOGIC END*******************************

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
