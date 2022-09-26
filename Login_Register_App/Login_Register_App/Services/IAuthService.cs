using Login_Register_App.Models;
using Login_Register_App.ViewModels;

namespace Login_Register_App.Services
{
    public interface IAuthService
    {
        public bool Login(LoginViewModel model);
        public bool Register(RegisterViewModel model);
        public byte[] EncryptPassword(string password);
        public string DecryptPassword(byte[] password);
    }
}
