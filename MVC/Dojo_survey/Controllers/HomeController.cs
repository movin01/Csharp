using Microsoft.AspNetCore.Mvc;


namespace Dojo_survey
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
        public IActionResult Result(string Yourname, string Cities, string Languages, string Comment)
        {
            ViewBag.name = Yourname;
            ViewBag.city = Cities;
            ViewBag.language = Languages;
            ViewBag.comment = Comment;
            
           return View("Result");
            }
    }
}
