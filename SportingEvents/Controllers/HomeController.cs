using Microsoft.AspNetCore.Mvc;
using SportingEvents.Models;
using System;

namespace SportingEvents.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View("Index");
        }

        [HttpPost]
        public ViewResult InputForm(Responses responses) 
        {
            Repository.AddResponse(responses);
            return View("WelcomeToGroup", responses);
        }

        public ViewResult Input()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetDetails() 
        {
            Responses usermodel = new Responses
            {
                Name = HttpContext.Request.Form["Name"].ToString(),
                DateOfBirth = HttpContext.Request.Form["DateOfBirth"].ToString(),
                Gender = HttpContext.Request.Form["Gender"].ToString(),
                Email = HttpContext.Request.Form["Email"].ToString(),
                Address = HttpContext.Request.Form["Address"].ToString(),
                PostCode = HttpContext.Request.Form["PostCode"].ToString(),
                HomeTelephoneNumber = HttpContext.Request.Form["HomeTelephoneNumber"].ToString(),
                MobileTelephoneNumber = HttpContext.Request.Form["MobileTelephoneNumber"].ToString(),
                Biography = HttpContext.Request.Form["Biography"].ToString(),
                SkillKeyWord = HttpContext.Request.Form["SkillKeyWord"].ToString(),
                WorkLocation = HttpContext.Request.Form["WorkLocation"].ToString()
            };

            int result = usermodel.SaveDetails();
            if (result > 0)
            {
                ViewBag.Result = " Registration Successful";
            }
            else 
            {
                ViewBag.Result = "Registration Unsuccessful";
            }
            return View("Input");
        }
    }
}
