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

        [HttpGet]
        public IActionResult Solve()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Solve(string Fizz, string Buzz)
        {
            var toNum1 = Convert.ToInt32(Fizz);
            var toNum2 = Convert.ToInt32(Buzz);
            var output = "";

            for (var i = 1; i <= 100; i++)
            {
                if((i % toNum1 == 0) && (i % toNum2 == 0))
                {
                    output += "FizzBuzz";
                }
                else if (i % toNum1 == 0)
                {
                    output += ($"{i} Fizz, ");
                }
                else if (i % toNum2 == 0)
                {
                    output += ($"{i} Buzz, ");
                }
                else
                {
                    output += $"{i}, ";
                }
            }


            ViewData["Output"] = output;

            return View();
        }

        public IActionResult Code()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
