using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyContact.Core.Utilities.Validation
{
    public static class Regexs
    {
        public static bool IsEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            return match.Success;
        }
        public static bool IsPhone(string phone)
        {
            Regex regex = new Regex("^\\+?[1-9][0-9]{7,14}$");
            Match match = regex.Match(phone);
            return match.Success;
        }
       
    }
}
