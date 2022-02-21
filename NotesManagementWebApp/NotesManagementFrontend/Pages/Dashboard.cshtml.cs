using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Net.Http;

namespace NotesManagementFrontend.Pages
{
    public class DashboardModel : PageModel
    {
       
        public void OnGet()
        {
            string userDetails = HttpContext.Session.GetString("userDetails");

            if (userDetails == null)
            {
                Response.Redirect("/");
            }
            else
            {
                ViewData["userDetails"] = userDetails;
            }
        }
        public void OnGetProfile()
        {
            string userDetails = HttpContext.Session.GetString("userDetails");

            if (userDetails == null)
            {
                Response.Redirect("/");
                
            }
            else
            {
                Response.Redirect("/profile");
            }
        }
        public void OnGetLogout()
        {
            HttpContext.Session.Remove("userDetails");
            Response.Redirect("/");
        }
    }
}
