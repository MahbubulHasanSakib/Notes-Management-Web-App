using Microsoft.AspNetCore.Mvc;
using NotesManagementBackend.Models;
using NotesManagementBackend.Repository;
using System.ComponentModel.DataAnnotations;

namespace NotesManagementBackend.Controllers
{
    [ApiController]
    public class RegisterController : Controller
    {
        private UserModel newUser = new UserModel();
        [HttpPost("api/register")]
        public IActionResult Index()
        {
            newUser.UserName = Request.Form["fullName"];
            newUser.DateOfBirth = Request.Form["birthDate"];
            newUser.Email = Request.Form["email"];
            newUser.Password = Request.Form["password"];

            //check validity of Registering user
            if (newUser.UserName.Length > 0  && new EmailAddressAttribute().IsValid(newUser.Email) && newUser.Password.Length>=6 && newUser.DateOfBirth.Length > 0)
            {
                bool isSuccess = UsersRepo.SaveNewUser(newUser);

                if (isSuccess)
                {   
                    return Ok();
                }
                else if (!isSuccess)
                {   
                    return StatusCode(409, "User already registered!");
                }
                else
                {
                    return StatusCode(500, "Internal server problem");
                }
                
            }

            else return StatusCode(400, "Please input in correct format");
        }


    }
}
