using Newtonsoft.Json;
using System.Collections.Generic;

namespace NotesManagementBackend.Authentication
{
    public class Authenticator
    {
        public static bool Authenticate(string data)
        {
            Dictionary<string, string> userInfo = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);
            string decrypted_email = TokenManager.ValidateToken(userInfo["token"]);

            if (userInfo["email"].Equals(decrypted_email))
            {
                return true;
            }
            return false;
        }

        public static string findEmail(string authData)
        {
            Dictionary<string, string> userInfo = JsonConvert.DeserializeObject<Dictionary<string, string>>(authData);
            return TokenManager.ValidateToken(userInfo["token"]);
        }
    }
}
