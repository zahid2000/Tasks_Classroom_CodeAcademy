using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_Tasks_Part2.Models
{
    public class Vehicle
    {
        public string Color { get; set; }
        private int _year;
        public int  Year {
            get { return _year; }
            set {
                if (value>=1900&&value<=2022)
                {
                    _year = value;
                }
                else
                {
                    throw new Exception("Year is not corret");
                }
            }
        }

        public Vehicle(int year)
        {
            Year = year;
        }
    }
}
