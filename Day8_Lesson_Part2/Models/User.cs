using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8_Lesson_Part2.Models
{
    public class User
    {
        public User()
        {

        }
        public User(string name, string surname, string username, string email, string password)
        {
            Name = name;
            Surname = surname;
            Username = username;
            Email = email;
            Password = password;
        }

        public string? Name { get; set; }
        public string? Surname { get; set; }
        private string? Username;
        private string? Email;
        
        public string? Password { get; set; }
        public void SetUserNameAndEmail(string userName, string email)
        {
            Username = userName;
            Email = email;
        }
       
        public string GetUsername() => Username;
        public string GetEmail() => Email;
    }
}
