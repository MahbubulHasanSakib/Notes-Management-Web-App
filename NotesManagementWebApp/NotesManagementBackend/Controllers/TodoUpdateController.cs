using Microsoft.AspNetCore.Mvc;
using NotesManagementBackend.Authentication;
using NotesManagementBackend.Repository;

namespace NotesManagementBackend.Controllers
{
    [ApiController]
    public class TodoUpdateController : Controller
    {
        [HttpPost("api/updateTodoStatus")]
        public IActionResult Index()
        {
            try
            {

                if (Authenticator.Authenticate(Request.Headers["Authorization"]))
                {
                    if (NotesRepo.updateTodoState(Request.Form["noteToBeUpdated"]))
                    {
                        return Ok();
                    }
                    else
                    {
                        return StatusCode(500, "Internal server problem");
                    }
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
