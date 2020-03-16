using Microsoft.AspNetCore.Mvc;
using SportingEvents.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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
        // 11/03/2020 ADDED ADMINISTRATOR
        public ActionResult Attendees() 
        {
            SqlConnection connection = new SqlConnection(CallConnectionString.ConnectionString());
            String sql = "SELECT * FROM UserInfo";
            SqlCommand cmd = new SqlCommand(sql, connection);

            var userList = new List<Responses>();
            using (connection) 
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) 
                {
                    var userResponse = new Responses();
                    userResponse.id = reader.GetInt32(0);
                    userResponse.Name = reader["Name"].ToString();
                    userResponse.DateOfBirth = reader["DateOfBirth"].ToString();
                    userResponse.Gender = reader["Gender"].ToString();
                    userResponse.Email = reader["Email"].ToString();
                    userResponse.Address = reader["Address"].ToString();
                    userResponse.PostCode = reader["PostCode"].ToString();
                    userResponse.HomeTelephoneNumber = reader["HomeTelephoneNumber"].ToString();
                    userResponse.MobileTelephoneNumber = reader["MobileTelephoneNumber"].ToString();
                    userResponse.Biography = reader["Biography"].ToString();
                    userResponse.SkillKeyWord = reader["SkillKeyWord"].ToString();
                    userResponse.WorkLocation = reader["WorkLocation"].ToString();

                    userList.Add(userResponse);
                }
            }
            return View(userList);
        }
    }
}
