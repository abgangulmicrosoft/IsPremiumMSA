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
            // Line breaks for legibility only
            // Content-Type: application/x-www-form-urlencoded
            /*
            string queryString = QueryHelpers.AddQueryString("", parameters);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url + queryString);
            request.Headers.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded");
            request.Content = new StringContent("application/x-www-form-urlencoded");//CONTENT-TYPE header
            request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
            request.Content.Headers.ContentEncoding.Add("UTF8");
            response = await httpClient.SendAsync(request);

            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded");
            request = new HttpRequestMessage(HttpMethod.Post, "http://login.microsoftonline.com/common/oauth2/v2.0/token");
            var keyValues = new List<KeyValuePair<string, string>>();
            keyValues.Add(new KeyValuePair<string, string>("client_id", "f1e1a7e0-4ae5-490d-91e6-45cc6ec5ee32"));
            keyValues.Add(new KeyValuePair<string, string>("scope", "user.read"));
            keyValues.Add(new KeyValuePair<string, string>("code", code));
            keyValues.Add(new KeyValuePair<string, string>("redirect_uri", "http://localhost:44328/home/addtoken/"));
            keyValues.Add(new KeyValuePair<string, string>("grant_type", "authorization_code"));
            keyValues.Add(new KeyValuePair<string, string>("client_secret", "jTVrDY4mP~5.D78q7EZXs3h.Luu8x4.p22"));

            request.Content = new FormUrlEncodedContent(keyValues);
            request.Method = HttpMethod.Post;
            response = httpClient.SendAsync(request).Result;
            */
            if (response.IsSuccessStatusCode)
            {
                var contents = await response.Content.ReadAsStringAsync();
                return contents;
                //return JsonConvert.DeserializeObject<object>(contents);
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