﻿using Microsoft.AspNetCore.Mvc;
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
        public string Post()
        {
            return "Posted";
        }
        public async Task<string> Get()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "https://ispremiummsa.azurewebsites.net/home/post");
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);
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