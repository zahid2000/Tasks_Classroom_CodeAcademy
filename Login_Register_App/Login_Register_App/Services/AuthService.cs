using Login_Register_App.Models;
using Login_Register_App.ViewModels;
using System.Text;

namespace Login_Register_App.Services
{
    public class AuthService : IAuthService
    {
        private readonly LoginRegisterDb _db;

        public AuthService(LoginRegisterDb db)
        {
            _db = db;
        }

        public string DecryptPassword(byte[] password)
        {
            return ASCIIEncoding.ASCII.GetString(password);
        }

        public byte[] EncryptPassword(string password)
        {
            return ASCIIEncoding.ASCII.GetBytes(password);
        }

        public bool Login(LoginViewModel model)
        {
            if (!ExistsUser(model.UserName))
            {
                return false;
            }
            var result = _db.Users.Where(u => u.UserName == model.UserName).SingleOrDefault();
            if (DecryptPassword(result.Password)!=model.Password)
            {
                return false;
            }
            
            return true;
        }

        public bool Register(RegisterViewModel model)
        {

            if (ExistsUser(model.User.UserName,model.User.Email))
            {
                return false;
            }
            model.User.Password=EncryptPassword(model.Password);
            _db.Users.Add(model.User);
            _db.SaveChanges();
            return true;
        }

        private bool ExistsUser(string userName, string email)
        {
            var result = _db.Users.Where(u => u.UserName == userName || u.Email == email).FirstOrDefault();
            if (result == null)
            {
                return false;
            }
            return true;
        }
        private bool ExistsUser(string userName)
        {
            var result = _db.Users.Where(u => u.UserName == userName ).FirstOrDefault();
            if (result == null)
            {
                return false;
            }
            return true;
        }
    }
}
