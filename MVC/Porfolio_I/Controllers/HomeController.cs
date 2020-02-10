using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace Porfolio_I.Controllers

{
    public class HomeController : Controller   //remember inheritance??
    {
        //for each route this controller is to handle:
        [HttpGet]       //type of request
        [Route("")]     //associated route string (exclude the leading /)
        public IActionResult Index()
        {
            return View();
        }


                //for each route this controller is to handle:
        [HttpGet]       //type of request
        [Route("page2")]     //associated route string (exclude the leading /)
        public IActionResult page2()
        {
            return View();
    }

                //for each route this controller is to handle:
        [HttpGet]       //type of request
        [Route("page3")]     //associated route string (exclude the leading /)
        public IActionResult page3()
        {
            return View();
    }
}
}