using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;


namespace WeddingPlanner.Controllers
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
            // HttpContext.Session.Clear();
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



        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetInt32("SessionUserID") == null)
            {
                return RedirectToAction("Index");
            }
            WrapperViewModelAll AllTheThings = new WrapperViewModelAll();
            AllTheThings.LoggedInUser = dbContext.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("SessionUserID"));
            AllTheThings.AllWeddings = dbContext.Weddings.Include(w => w.Responses).ToList();
            AllTheThings.AllUsers = dbContext.Users.ToList();
            return View(AllTheThings);


        }
        [HttpGet]
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        [Route("NewWeddingPage")]
        public IActionResult NewWeddingPage()
        {

            return View("NewWeddingPage");
        }




        [HttpPost("CreateWedding")]
        public IActionResult CreateWedding(Wedding newWedder)
        {
            if (HttpContext.Session.GetInt32("SessionUserID") == null)
            {
                return RedirectToAction("Index");
            }
            if (ModelState.IsValid)
            {
                // create foriegn key to something else
                newWedder.CreatorId = (int)HttpContext.Session.GetInt32("SessionUserID");
                // do somethng!  maybe insert into db?  then we will redirect
                dbContext.Add(newWedder);
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard", newWedder);
            }
            return View("NewWeddingPage");
        }
        [HttpGet("Delete/{WeddingID}")]
        public IActionResult Delete(int weddingID)
        {
            if (HttpContext.Session.GetInt32("SessionUserID") == null)
            {
                return RedirectToAction("Index");
            }
            Wedding newwedding = dbContext.Weddings.FirstOrDefault(a => a.WeddingID == weddingID);
            if (HttpContext.Session.GetInt32("SessionUserID") != newwedding.CreatorId)
            {
                return RedirectToAction("Dashboard");
            }
            Wedding Deletewedding = dbContext.Weddings.FirstOrDefault(w => w.WeddingID == weddingID);
            if (Deletewedding == null)
            {
                return RedirectToAction("Dashboard");
            }
            dbContext.Weddings.Remove(Deletewedding);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        [HttpGet("RSVP/{WeddingID}")]
        public IActionResult RSVP(int weddingID)
        {
            if (HttpContext.Session.GetInt32("SessionUserID") == null)
            {
                return RedirectToAction("Index");
            }
            WrapperViewModelAll AllThings = new WrapperViewModelAll();
            AllThings.OneAssociation = new Association();
            AllThings.OneAssociation.UserId = (int)HttpContext.Session.GetInt32("SessionUserID");
            AllThings.OneAssociation.WeddingId = weddingID;
            Wedding OneWedding = dbContext.Weddings.Include(g => g.Responses).FirstOrDefault(r => r.WeddingID == weddingID);
            dbContext.Add(AllThings.OneAssociation);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }



        [HttpGet("Leave/{WeddingID}")]
        public IActionResult Leave(int weddingID)
        {
            if (HttpContext.Session.GetInt32("SessionUserID") == null)
            {
                return RedirectToAction("Index");
            }
            WrapperViewModelAll AllThings = new WrapperViewModelAll();
            AllThings.OneAssociation = new Association();
            AllThings.OneAssociation.UserId = (int)HttpContext.Session.GetInt32("SessionUserID");
            AllThings.OneAssociation.WeddingId = weddingID;
            Association thisrsvp = dbContext.Associations.FirstOrDefault(a => a.WeddingId == weddingID && a.UserId == AllThings.OneAssociation.UserId);
            if (thisrsvp == null)
            {
                return RedirectToAction("Dashboard");
            }
            dbContext.Remove(thisrsvp);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }




        [HttpGet("{WeddingID}")]
        public IActionResult Detailspage(int weddingID)
        {
            if (HttpContext.Session.GetInt32("SessionUserID") == null)
            {
                return RedirectToAction("Index");
            }
            WrapperViewModelAll AllThings = new WrapperViewModelAll();
            AllThings.OneWedding=dbContext.Weddings.FirstOrDefault(a => a.WeddingID==weddingID);
            AllThings.AllWeddings=dbContext.Weddings.Include(c => c.Responses).ToList();
            AllThings.AllUsers=dbContext.Users.Include(b => b.Participants).ToList();
            return View("Detailspage",AllThings);
        }
    }
}
