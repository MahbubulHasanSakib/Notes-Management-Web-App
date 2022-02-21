using Microsoft.AspNetCore.Mvc;
using NotesManagementBackend.Authentication;
using NotesManagementBackend.Repository;

namespace NotesManagementBackend.Controllers
{
    [ApiController]
    public class searchNotesController : Controller
    {
        [HttpPost("api/searchNotes")]
        public IActionResult Index()
        {
            try
            {
                if (Authenticator.Authenticate(Request.Headers["Authorization"]))
                {
                    //return matched notes
                    string notes = NotesRepo.GetAllNotes(Authenticator.findEmail(Request.Headers["Authorization"]), Request.Form["search"]);

                    return Content(notes);
                }

                return StatusCode(401, "Unauthorized access");
            }
            catch
            {
                return StatusCode(500, "Internal server problem");
            }
        }
    }
}
