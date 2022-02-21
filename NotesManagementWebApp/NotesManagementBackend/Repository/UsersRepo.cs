using NotesManagementBackend.Models;
using System.Collections.Generic;

namespace NotesManagementBackend.Repository
{
    public class UsersRepo
    {
     
        private static List<UserModel> usersList = new List<UserModel>();

        public static bool SaveNewUser(UserModel newUser)
        {
            for (int i = 0; i < usersList.Count; i++)
            {
               
                if (newUser.Email.Equals(usersList[i].Email))
                {
                    return false;
                }
            }
           
            usersList.Add(newUser);
            return true;
        }

        public static UserModel GetUser(string email, string password)
        {
            for (int i = 0; i < usersList.Count; i++)
            {
                if (usersList[i].Email.Equals(email) && usersList[i].Password.Equals(password))
                {
                    return usersList[i];
                }
            }

            return null; 
        }
    }
}
