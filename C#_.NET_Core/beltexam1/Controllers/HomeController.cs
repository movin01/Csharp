using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using beltexam1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;


namespace beltexam1.Controllers
{
    public class HomeController : Controller
    {
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
        public IActionResult Dashboard(int ideaId)
        {
            if (HttpContext.Session.GetInt32("SessionUserID") == null)
            {
                return RedirectToAction("Index");
            }
            WrapperViewModelAll AllTheThings = new WrapperViewModelAll();
            Idea new_idea = new Idea();
            AllTheThings.OneIdea = new_idea;
            AllTheThings.OneIdea.goodIdea = "";
            // AllTheThings.OneIdea = dbContext.Ideas.FirstOrDefault(c => c.IdeaId == ideaId);
            AllTheThings.LoggedInUser = dbContext.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("SessionUserID"));
            AllTheThings.AllIdeas = dbContext.Ideas.Include(w => w.Responses).ThenInclude(c => c.Like).ToList();
            // AllTheThings.AllUsers = dbContext.Users.ToList();
            return View(AllTheThings);
        }


        [HttpPost("idea_validation")]
        public IActionResult Idea_Validation(WrapperViewModelAll new_idea)
        {
            if (HttpContext.Session.GetInt32("SessionUserID") == null)
            {
                 return RedirectToAction("Index");
            }
            if (new_idea.OneIdea.goodIdea == null || new_idea.OneIdea.goodIdea.Length < 5)
            {
                WrapperViewModelAll AllTheThings = new WrapperViewModelAll();
                AllTheThings.OneIdea = new_idea.OneIdea;
                AllTheThings.OneIdea.goodIdea = "Please enter a longer description";
                AllTheThings.LoggedInUser = dbContext.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("SessionUserID"));
                AllTheThings.AllIdeas = dbContext.Ideas.Include(w => w.Responses).ThenInclude(c => c.Like).ToList();
                return View("Dashboard", AllTheThings);
            } 
            new_idea.OneIdea.CreatorId = (int)HttpContext.Session.GetInt32("SessionUserID");
            // new_idea.OneIdea.Creator = dbContext.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("SessionUserID"));
            
            if (ModelState.IsValid)
            {
                dbContext.Add(new_idea.OneIdea);
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View("Dashboard");
            }
        }


        [HttpPost("CreateIdea")]
        public IActionResult CreateIdea(Idea newIdea)
        {
            if (HttpContext.Session.GetInt32("SessionUserID") == null)
            {
                return RedirectToAction("Index");
            }
            if (ModelState.IsValid)
            {
                // create foriegn key to something else
                newIdea.CreatorId = (int)HttpContext.Session.GetInt32("SessionUserID");
                // do somethng!  maybe insert into db?  then we will redirect
                dbContext.Add(newIdea);
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard", newIdea);
            }
            return View("NewIdeaPage");
        }




        [HttpGet]
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }





        [HttpGet]
        [Route("NewIdeaPage")]
        public IActionResult NewIdeaPage()
        {
            return View("NewIdeaPage");
        }





        [HttpGet("Delete/{IdeaId}")]
        public IActionResult Delete(int ideaId)
        {
            if (HttpContext.Session.GetInt32("SessionUserID") == null)
            {
                return RedirectToAction("Index");
            }
            Idea newidea = dbContext.Ideas.FirstOrDefault(a => a.IdeaId == ideaId);
            if (HttpContext.Session.GetInt32("SessionUserID") != newidea.CreatorId)

            {
                return RedirectToAction("Dashboard");
            }
            Idea Deleteidea = dbContext.Ideas.FirstOrDefault(w => w.IdeaId == ideaId);
            if (Deleteidea == null)
            {
                return RedirectToAction("Dashboard");
            }
            dbContext.Ideas.Remove(Deleteidea);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }


        [HttpGet("Like/{IdeaId}")]
        public IActionResult Like(int ideaId)
        {
            if (HttpContext.Session.GetInt32("SessionUserID") == null)
            {
                return RedirectToAction("Index");
            }
            WrapperViewModelAll AllThings = new WrapperViewModelAll();
            AllThings.OneAssociation = new Association();
            AllThings.OneAssociation.UserId = (int)HttpContext.Session.GetInt32("SessionUserID");
            AllThings.OneAssociation.IdeaId = ideaId;
            Idea OneIdea = dbContext.Ideas.Include(g => g.Responses).FirstOrDefault(r => r.IdeaId == ideaId);
            dbContext.Add(AllThings.OneAssociation);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }


        [HttpGet("Likerspage/{ideaId}")]
        public IActionResult Likerspage(int ideaId)
        {
            if (HttpContext.Session.GetInt32("SessionUserID") == null)
            {
                return RedirectToAction("Index");
            }
            WrapperViewModelAll AllThings = new WrapperViewModelAll();
            AllThings.OneIdea = dbContext.Ideas.Include(c => c.Responses).ThenInclude(c => c.Like).FirstOrDefault(a => a.IdeaId == ideaId);
            AllThings.AllIdeas = dbContext.Ideas.Include(c => c.Responses).ToList();
            AllThings.AllUsers = dbContext.Users.Include(b => b.Participants).ToList();
            return View("Likerspage", AllThings);
        }




        [HttpGet("{IdeaId}")]
        public IActionResult Detailspage(int ideaId)
        {
            if (HttpContext.Session.GetInt32("SessionUserID") == null)
            {
                return RedirectToAction("Index");
            }
            WrapperViewModelAll AllThings = new WrapperViewModelAll();
            AllThings.OneIdea = dbContext.Ideas.Include(c => c.Responses).ThenInclude(c => c.Like).FirstOrDefault(a => a.IdeaId == ideaId);
            AllThings.AllIdeas = dbContext.Ideas.Include(c => c.Responses).ToList();
            AllThings.AllUsers = dbContext.Users.Include(b => b.Participants).ToList();
            return View("Detailspage", AllThings);
        }




        [HttpGet("Unlike/{IdeaId}")]
        public IActionResult Leave(int ideaId)
        {
            if (HttpContext.Session.GetInt32("SessionUserID") == null)
            {
                return RedirectToAction("Index");
            }
            WrapperViewModelAll AllThings = new WrapperViewModelAll();
            AllThings.OneAssociation = new Association();
            AllThings.OneAssociation.UserId = (int)HttpContext.Session.GetInt32("SessionUserID");
            AllThings.OneAssociation.IdeaId = ideaId;
            Association thisrsvp = dbContext.Associations.FirstOrDefault(a => a.IdeaId == ideaId && a.UserId == AllThings.OneAssociation.UserId);
            if (thisrsvp == null)
            {
                return RedirectToAction("Dashboard");
            }
            dbContext.Remove(thisrsvp);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }


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
