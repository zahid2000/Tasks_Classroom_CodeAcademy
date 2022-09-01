using Day8_Lesson_Part2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8_Lesson_Part2.Services
{
    public class UserService
    {
        public static User SetUserInfo(User user)
        {
            string username = $"{user.Name}.{user.Surname}";
            string password = $"{user.Name}.{user.Surname}@gmail.com";
            user.SetUserNameAndEmail(username, password);
            return user;
        }
    }
}
