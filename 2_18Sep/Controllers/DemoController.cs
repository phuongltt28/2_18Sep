using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using _2_18Sep.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _2_18Sep.Controllers
{
    public class DemoController : Controller
    {
        #region uploadFile
        //Lab2: upload file
        [HttpGet]
        public IActionResult Upload()
        {
            return View("Upload");
        }
        [HttpPost]
        public IActionResult ProcessSingleFile(IFormFile MyFile)
        {
            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Data", MyFile.FileName);
            using(var file = new FileStream(fullPath, FileMode.Create))
            {
                MyFile.CopyTo(file);
            }
            return RedirectToAction("Upload");
        }

        [HttpPost]
        public IActionResult ProcessMultipleFile(List<IFormFile> MyFiles)
        {
            var folder = Path.Combine(Directory.GetCurrentDirectory(), "MyData");
            foreach(var myFile in MyFiles)
            {
                var fullPath = Path.Combine(folder, myFile.FileName);

                using (var file = new FileStream(fullPath, FileMode.Create))
                {
                    myFile.CopyTo(file);
                }
            }
            
            return RedirectToAction("Upload");
        }
        #endregion
        public IActionResult Index()
        {
            return View("Calculate");
        }

        public IActionResult DemoSync()
        {
            var demo = new Demo();
            var dongHo = new Stopwatch();
            dongHo.Start();
            demo.FunctionA();
            demo.FunctionB();
            demo.FunctionC();
            dongHo.Stop();

            return Content($"Chạy hết {dongHo.ElapsedMilliseconds} ms");
        }
        public async Task<IActionResult> DemoASync()
        {
            var demo = new Demo();
            var dongHo = new Stopwatch();
            dongHo.Start();
            var a = demo.FunctionAAsync();
            var b = demo.FunctionBAsync();
            var c = demo.FunctionCAsync();
            await a; await b; await c;
            dongHo.Stop();

            return Content($"Chạy hết {dongHo.ElapsedMilliseconds} ms");
        }

        //URL friendly
        [Route("/dien-thoai/{tenDienThoai}")]
        public string ABCDEF(string tenDienThoai)
        {
            return $"Điện thoại {tenDienThoai}";
        }

        public IActionResult Calculate(double a = 0, double b = 0, char op = '+')
        {
            switch (op)
            {
                case '+':
                    ViewBag.KetQua = a + b;
                    break;
                case '-':
                    ViewBag.KetQua = a - b;
                    break;
                case '*':
                    ViewBag.KetQua = a * b;
                    break;
                case ':':
                    ViewBag.KetQua = a / b;
                    break;
            }
            return View("Calculate");
        }
    }
}