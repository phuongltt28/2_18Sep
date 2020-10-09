using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _2_18Sep.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace _2_18Sep.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(StudentInfo info, string Save)
        {
            if (Save == "Save JSON")
            {
                var json = JsonConvert.SerializeObject(info);
                //Net 3.x
                //json = System.Text.Json.JsonSerializer.Serialize(info);
                System.IO.File.WriteAllText("data.txt", json);
            }
            return View();
        }
    }
}