using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;


namespace CRUDelicious.Controllers
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
            List<Dish> alldishes = dbContext.Dishes.ToList();
            return View(alldishes);
        }
        // [HttpPost]
        [Route("new_page")]
        public IActionResult new_page()
        {
            return View("new_page");
        }
        [HttpPost("Create")]
        public IActionResult Create(Dish newdish)
        {
            if (ModelState.IsValid)
            {

                // do somethng!  maybe insert into db?  then we will redirect
                dbContext.Add(newdish);
                dbContext.SaveChanges();
                return RedirectToAction("Index", newdish);
            }
            return View("new_page");
        }
        [HttpGet("{MyDishID}")]
        public IActionResult DishDetails(int MyDishID)
        {
            Dish One_dish = dbContext.Dishes.FirstOrDefault(d => d.DishID == MyDishID);

            return View("Details", One_dish);
        }
        [HttpGet("Edit/{MyDishID}")]
        public IActionResult Edit(int MyDishID)
        {
            Dish One_dish = dbContext.Dishes.FirstOrDefault(d => d.DishID == MyDishID);

            return View("Edit", One_dish);

        }
        [HttpPost("Update/{MyDishID}")]
        public IActionResult Update(int MyDishID, Dish MyDish)
        {
            Dish One_dish = dbContext.Dishes.FirstOrDefault(d => d.DishID == MyDishID);
            if (ModelState.IsValid)
            {
                //    One_dish.DishID = MyDishID;
                // dbContext.Update(One_dish);
                // dbContext.Entry(One_dish).Property("CreatedAt").IsModified = false;
                One_dish.Name = MyDish.Name;
                One_dish.Chef = MyDish.Chef;
                One_dish.Calories = MyDish.Calories;
                One_dish.Description = MyDish.Description;
                One_dish.Tastiness = MyDish.Tastiness;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Update/{MyDishID}");
            }
        }
        [HttpGet("Delete/{MyDishID}")]
        public IActionResult Delete(int MyDishID)
        {
            Dish One_dish = dbContext.Dishes.FirstOrDefault(d => d.DishID == MyDishID);
            dbContext.Dishes.Remove(One_dish);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}