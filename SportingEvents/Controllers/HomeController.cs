using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportingEvents.Models;

namespace SportingEvents.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View("InviteView");
        }

        [HttpGet]
        public ViewResult InputForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult InputForm(Responses responses) 
        {
            Repository.AddResponse(responses);
            return View("WelcomeToGroup", responses);
        }

        //public ViewResult ListOfUpcomingGames() 
        //{
        //    return View(Repository.responses.Where(r => r.ListOfGames == true));
        //}


    }
}
