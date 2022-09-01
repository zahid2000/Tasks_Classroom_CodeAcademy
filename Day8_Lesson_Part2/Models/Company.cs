using Day8_Lesson_Part2.Delegates;
using Day8_Lesson_Part2.ILogger;
using Day8_Lesson_Part2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day8_Lesson_Part2.Models
{
    public delegate string UserInfodelegate(string username, string password);
    public delegate void LoggerManager(string message);



    public class Company
    {
        ConsoleLogger logger = new ConsoleLogger();


        public string Name { get; set; }
        private List<User> Users = new List<User>();
        

        public void Register(User user)
        {
            if (RegisterCheck(user))
            {
                LoggerManager loggerDelegate = new LoggerManager(logger.Log);
                Users.Add(user);
                loggerDelegate.Invoke($"Tebrikler.IStifadeci melumatlari daxil edildi.\n UserName -> {user.GetUsername()} , Email -> {user.GetEmail()} , Password -> {user.Password} ");
            }
        }

        public bool Login(string username, string password)
        {
            LoggerManager loggerDelegate = new LoggerManager(logger.Log);

            var result = Users.Find(u => u.GetUsername() == username && u.Password == password);
            if (result == null)
            {
                loggerDelegate.Invoke("Melumatlari duzgun daxil edin");
                return false;
            }
            loggerDelegate.Invoke("Tebrikler. Hesaba daxil oldunuz!");
            return true;


        }
        public bool RegisterCheck(User user)
        {
            LoggerManager loggerDelegate = new LoggerManager(logger.Log);
           
            user = UserService.SetUserInfo(user);
            bool result = Users.Find(u=>u.Name==user.Name&&u.Surname==user.Surname&&u.GetUsername()==user.GetUsername())!=null;
            if (result)
            {
                loggerDelegate.Invoke("Bu istifadeci artiq var");
                return false;
            }
            else return true;
        }
        public bool checkSurname(string surname)
        {
            LoggerManager loggerDelegate = new LoggerManager(logger.Log);
            
           if (string.IsNullOrEmpty(surname) || string.IsNullOrWhiteSpace(surname))
            {
                loggerDelegate.Invoke("Istifadeci soyadi bos ola bilmez");
             
            }
            if (surname.Length < 5)
            {
                loggerDelegate.Invoke("Istifadeci soyadi minimum 5 simvol olmalidir");
                return false;
            }
            return true;
        }
        public bool checkUsername(string username)
        {
            LoggerManager loggerDelegate = new LoggerManager(logger.Log);

            if (string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username))
            {
                loggerDelegate.Invoke("Istifadeci adi bos ola bilmez");

            }
            if (username.Length < 3)
            {
                loggerDelegate.Invoke("Istifadeci adi minimum 3 simvol olmalidir");
                return false;
            }
            return true;
        }
        public bool checkPassword(string password)
        {
            LoggerManager loggerDelegate = new LoggerManager(logger.Log);
            if (string.IsNullOrEmpty(password)|| string.IsNullOrWhiteSpace(password))
            {
                loggerDelegate.Invoke("Password bos ola bilmez ola bilmez!");
                return false;
            }
            if ( password.Length < 8)
            {
                loggerDelegate.Invoke("Password 8 simvoldan az ola bilmez ola bilmez!");
             
            }
            if (!Char.IsUpper(password[0]))
            {
                loggerDelegate.Invoke("Password ilk simvolu kicik olar bilmez!");
                 
            }
           
                Regex regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-zA-Z]).*$");
                Match match = regex.Match(password);
                if (!match.Success)
                {
                    loggerDelegate.Invoke("Passwordda en azi bir reqem olmalidir!");
                    return match.Success;
                }
                return match.Success;
            
        }
        public List<User> GetUsers() => Users;
    }
}
