using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
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
            const string url = "https://login.microsoftonline.com/common/oauth2/v2.0/authorize";
            var parameters = new Dictionary<string, string>();
            parameters["client_id"] = "f1e1a7e0-4ae5-490d-91e6-45cc6ec5ee32";
            parameters["response_type"] = "code";
            parameters["redirect_uri"] = "https://localhost:44328/home/addcode";
            parameters["response_mode"] = "query";
            parameters["scope"] = "offline_access user.read";
            ViewBag.url =  QueryHelpers.AddQueryString(url, parameters);
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public async Task<string> AddCode(string code)
        {
            const string url = "http://login.microsoftonline.com/common/oauth2/v2.0/token";
            HttpClient httpClient = new HttpClient();
            var parameters = new Dictionary<string, string>();
            parameters["client_id"] = "f1e1a7e0-4ae5-490d-91e6-45cc6ec5ee32";
            parameters["scope"] = "user.read";
            parameters["code"] = code;
            parameters["redirect_uri"] = "https://localhost:44328/home/addtoken/";
            parameters["grant_type"] = "authorization_code";
            parameters["client_secret"] = "jTVrDY4mP~5.D78q7EZXs3h.Luu8x4.p22";
 
            var content = new FormUrlEncodedContent(parameters);
            HttpResponseMessage response = await httpClient.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                var contents = await response.Content.ReadAsStringAsync();
                return contents;
            }
            else
            {
                return response.ReasonPhrase;
            }
        }
        public IActionResult AddToken()
        {
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