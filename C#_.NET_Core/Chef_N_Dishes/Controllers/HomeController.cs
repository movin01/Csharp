using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Chef_N_Dishes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;


namespace Chef_N_Dishes.Controllers
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
            List<Chef> allchefs = dbContext.Chefs.Include(d => d.CreatedDishes).ToList();
            return View(allchefs);
        }
        [HttpPost("CreateChef")]
        public IActionResult CreateChef(Chef newChef)
        {
            if (ModelState.IsValid)
            {

                // do somethng!  maybe insert into db?  then we will redirect
                dbContext.Add(newChef);
                dbContext.SaveChanges();
                return RedirectToAction("Index", newChef);
            }
            return View("Addchef");
        }
        [HttpGet]
        [Route("AddChef")]
        public IActionResult AddChefpage()
        {
            return View("AddChef");
        }
        [HttpPost("CreateDish")]
        public IActionResult CreateDish(WrapperViewModel newdish)
        {
            if (ModelState.IsValid)
            {
                // do somethng!  maybe insert into db?  then we will redirect
                dbContext.Dishes.Add(newdish.OneDish);
                dbContext.SaveChanges();
                return RedirectToAction("ListofDishpage");
            }    
            WrapperViewModel newwrap = new WrapperViewModel();
            newwrap.AllChefs = dbContext.Chefs.ToList();
            return View("AddDishespage", newwrap);
        }
        [HttpGet]
        [Route("AddDishespage")]
        public IActionResult AddDishespage()
        {
            WrapperViewModel newwrap = new WrapperViewModel();
            newwrap.AllChefs = dbContext.Chefs.ToList();
            return View("AddDishespage", newwrap);
        }

    [HttpGet]
        [Route("ListofDishpage")]
        public IActionResult ListofDishpage()
        {
           WrapperViewModel newwrap = new WrapperViewModel();
            newwrap.AllDishes = dbContext.Dishes
           .Include(b => b.Creator)
           .ToList();
            return View("ListofDishpage",newwrap);
        }






        /////////////////////////////////////////////////////////////////////////////
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
