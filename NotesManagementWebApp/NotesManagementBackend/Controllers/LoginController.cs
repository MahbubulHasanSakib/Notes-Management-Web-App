using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NotesManagementBackend.Authentication;
using NotesManagementBackend.Models;
using NotesManagementBackend.Repository;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace NotesManagementBackend.Controllers
{
    public class LoginController : Controller
    {
        private UserModel newUser = new UserModel();

        [HttpPost("api/login")]
        public async Task<IActionResult> Index()
        {
            try
            {
                using (var sr = new StreamReader(Request.Body))
                {
                    //parsing user requested data 
                    string body = await sr.ReadToEndAsync();
                    Hashtable hashtable = JsonConvert.DeserializeObject<Hashtable>(body);
                    // read user data from local memory
                    newUser = UsersRepo.GetUser(hashtable["email"].ToString(), hashtable["password"].ToString());
                    if (newUser != null)
                    {
                        //create jwt token
                        string token = TokenManager.GenerateToken(newUser.Email);
                        //create user data dictionary with token
                        Dictionary<string, string> userData = new Dictionary<string, string>();
                        userData.Add("fullName", newUser.UserName);
                        userData.Add("email", newUser.Email);
                        userData.Add("birthDate", newUser.DateOfBirth);
                        userData.Add("token", token);
                        string json = JsonConvert.SerializeObject(userData);
                        return StatusCode(200, json);
                    }
                    else
                    {
                        return StatusCode(403, "Wrong informations!");
                    }
                }
            }
            catch
            {
                return StatusCode(500, "Internal server problem");
            }
        }
    }
}
