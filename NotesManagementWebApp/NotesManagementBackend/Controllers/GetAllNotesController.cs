using Microsoft.AspNetCore.Mvc;
using NotesManagementBackend.Authentication;
using NotesManagementBackend.Repository;

namespace NotesManagementBackend.Controllers
{
    [ApiController]
    public class GetAllNotesController : Controller
    {
        [HttpGet("api/getAllNotes")]
        public IActionResult Index()
        {
            try
            {
                string data = Request.Headers["Authorization"];
                if (Authenticator.Authenticate(data))
                {
                    //return data
                    string notes = NotesRepo.GetAllNotes(Authenticator.findEmail(data));
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
