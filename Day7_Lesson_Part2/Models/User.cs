using Day7_Lesson_Part2.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7_Lesson_Part2.Models
{
    public class User
    {
     
        public string Name { get; set; }
        [ValidEmail]
        public string Email { get; set; }
        [ValidPasssword]
        public string Password { get; set; }
    }
}
