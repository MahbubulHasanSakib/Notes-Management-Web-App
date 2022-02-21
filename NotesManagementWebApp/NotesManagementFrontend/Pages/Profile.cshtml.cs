using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NotesManagementFrontend.Pages
{
    public class ProfileModel : PageModel
    {
        public void OnGet()
        {
            string userDetails = HttpContext.Session.GetString("userDetails");

            if (userDetails != null)
            {
                ViewData["userDetails"] = userDetails;
              
            }
            else
            {
                Response.Redirect("/");
            }
        }
        public void OnGetLogout()
        {
            HttpContext.Session.Remove("userDetails");
            Response.Redirect("/");
        }

    }
}
