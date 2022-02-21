using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NotesManagementFrontend.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            string userDetails = HttpContext.Session.GetString("userDetails");
            ViewData["userDetails"] = userDetails;
            if (userDetails != null)
            {
                Response.Redirect("/dashboard");
            }
        }

        //for login request('post')
        public async Task<IActionResult> OnPostLogin()
        {
            var loginInfo = new JObject();
            loginInfo.Add("email", (string)Request.Form["email"]);
            loginInfo.Add("password", (string)Request.Form["password"]);
            using (var client = new HttpClient())
            {
                try
                {
                    var res = await client.PostAsync(Helpers.Helpers.apiRootUrl + "login", new StringContent(loginInfo.ToString(), Encoding.UTF8, "application/json"));

                    if (res.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        //creating session for the authenticated user with JWT token
                        string userDetails = await res.Content.ReadAsStringAsync();
                        HttpContext.Session.SetString("userDetails", userDetails);
                        return Redirect("/dashboard");
                    }
                    else
                    {
                        return StatusCode(403, "Login failed! Wrong credentials");
                    }
                }
                catch
                {
                    return StatusCode(500,"Internal Server problem");
                }
            }
        }
    }
}
