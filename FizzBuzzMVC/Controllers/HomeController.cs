using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FizzBuzzMVC.Models;

namespace FizzBuzzMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Solution()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Solution(int fizz, int buzz, int limit)
        {
            fizz = fizz >= 1 ? fizz : 3;
            buzz = buzz >= 1 ? buzz : 5;
            limit = limit >= 1 ? limit : 100;
            var nums = new List<string>();
            for(var i = 1; i <= limit; i++)
            {
                if(i % fizz == 0 && i % buzz == 0)
                {
                    nums.Add("Fizz Buzz");
                } 
                else if (i % fizz == 0)
                {
                    nums.Add("Fizz");
                } 
                else if (i % buzz == 0)
                {
                    nums.Add("Buzz");
                }
                else
                {
                    nums.Add(i.ToString());
                }                
            }
            ViewData["Data"] = string.Join(" ", nums);
            return View();
        }

        [HttpPost]
        public IActionResult Clear ()
        {
            ViewData["Data"] = "";
            return View("Solution");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
