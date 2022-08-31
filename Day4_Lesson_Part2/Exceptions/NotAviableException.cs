using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_Lesson_Part2.Models.Exceptions
{
    public class NotAviableException:Exception
    {
        public NotAviableException(string message):base(message)
        {

        }
    }
}
