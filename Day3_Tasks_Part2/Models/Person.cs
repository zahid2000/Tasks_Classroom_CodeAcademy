using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_Tasks_Part2.Models
{
    public class Person
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length>8 )
                {
                    _name = value;
                }
                else throw new Exception("Name length must be 8 character");
            }
        }
        public string Surname { get; set; }
        private int _age;
        public int Age {
            get { return _age; }
            set
            {
                if (value <= 150 && value >= 0)
                {
                    _age = value;
                }
                else throw new Exception("Age is not correct"); 
            }
        }
        public string GetFullName()
        {
            return Name+" "+Surname;
        }
    }
}
