using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

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
        public string Post(string code)
        {
            return "Posted code " + code;
        }
        public async Task<string> Get()
        {
            HttpClient client = new HttpClient();
            var parameters = new Dictionary<string, string>();
            parameters["code"] = "test";
            HttpResponseMessage response = await client.PostAsync("https://ispremiummsa.azurewebsites.net/home/post", new FormUrlEncodedContent(parameters));
            if (response.IsSuccessStatusCode)
            {
                var contents = await response.Content.ReadAsStringAsync();
                return "Success Posting - " + contents;
            }
            else
            {
                return response.ReasonPhrase;
            }
        }
    }
}