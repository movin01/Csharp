using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Porfolio_II.Models;

namespace Porfolio_II.Controllers
{
    public class HomeController : Controller
    {
        //for each route this controller is to handle:
        [HttpGet]       //type of request
        [Route("")]     //associated route string (exclude the leading /)-         -------------------                                        
        public IActionResult Index()
        {
            return View();
        }
                //for each route this controller is to handle:
        [HttpGet]       //type of request
        [Route("projects")]     //associated route string (exclude the leading /)
        public IActionResult projects()
        {
            return View();
    }
                //for each route this controller is to handle:
        [HttpGet]       //type of request
        [Route("contact")]     //associated route string (exclude the leading /)
        public IActionResult contact()
        {
            return View();
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
