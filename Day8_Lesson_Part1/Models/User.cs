using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8_Lesson_Part1.Models
{
    internal class User:ValidationAttribute
    {
        public override bool IsValid(object? value )
        {
            return true;
        }
    }
}
