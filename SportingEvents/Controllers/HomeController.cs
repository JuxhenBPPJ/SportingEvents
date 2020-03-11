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
        public ActionResult Administrator() 
        {
            SqlConnection connection = new SqlConnection(CallConnectionString.ConnectionString());
            String sql = "SELECT * FROM UserInfo";
            SqlCommand cmd = new SqlCommand(sql, connection);

            var userList = new List<ResponsesList>();
            using (connection) 
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) 
                {
                    var Responses = new Responses();
                    Responses.id = reader.GetInt32(0);
                    Responses.Name = reader["Name"].ToString();
                    Responses.DateOfBirth = reader["DateOfBirth"].ToString();
                    Responses.Gender = reader["Name"].ToString();
                    Responses.Email = reader["Name"].ToString();
                    Responses.Address = reader["Name"].ToString();
                    Responses.PostCode = reader["Name"].ToString();
                    Responses.HomeTelephoneNumber = reader["Name"].ToString();
                    Responses.MobileTelephoneNumber = reader["Name"].ToString();
                    Responses.Biography = reader["Name"].ToString();
                    Responses.SkillKeyWord = reader["Name"].ToString();
                    Responses.WorkLocation = reader["Name"].ToString();

                    ResponsesList.Add(Responses);
                }
            }
            return View(ResponsesList);
        }
    }
}
