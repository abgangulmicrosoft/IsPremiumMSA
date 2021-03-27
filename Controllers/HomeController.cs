using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDotNetCppThreejs.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Add(string code)
        {
            ViewBag.code = code;
            return View();
        }
        [HttpPost]
        public string Post()
        {
            return "Posted";
        }
    }
}