using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dojo_survey_with_model.Models;

namespace Dojo_survey_with_model.Controllers
{
    public class HomeController : Controller
    {
        //for each route this controller is to handle:
        [HttpGet]       //type of request
        [Route("")]     //associated route string (exclude the leading /)
        public IActionResult Index()
        {
            return View();
        }
        // remember to use [HttpPost] attributes!
        [HttpPost]
        [Route("result")]
        public IActionResult Result(User newuser)
        {
            return View(newuser);
        }
    }
}
