using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_Tasks_Part2.Models
{
    public class Car:Vehicle
    {
       

        public string Brand { get; set; }
        public string Model { get; set; }
        private int _fuelCapasity;
        public int FuelCapasity
        {
            get { return _fuelCapasity; }
            set
            {
                if (value>=0)
                {
                    _fuelCapasity = value;
                }
                else
                {
                    throw new Exception("Value can't be negative");
                }
            }
        }

        private int _fuelFor1Km;
        public int FuelFor1Km
        {
            get { return _fuelFor1Km; }
            set
            {
                if (value >= 0)
                {
                    _fuelFor1Km = value;
                }
                else
                {
                    throw new Exception("Value can't be negative");
                }
            }
        }
        private int _currentFuel;
        public int CurrentFuel
        {
            get { return _currentFuel; }
            set
            {
                if (value >=0)
                {
                    _currentFuel = value;
                }
                else
                {
                    throw new Exception("Value can't be negative");
                }
            }
        }
        public Car(int year, string brand, string model, int fuelCapasity, int fuelFor1Km) : base(year)
        {
            Brand = brand;
            Model = model;
            FuelCapasity = fuelCapasity;
            FuelFor1Km = fuelFor1Km;
        }
        public Car(int year, string brand, string model, int fuelCapasity, int fuelFor1Km,int CurrentFuel) : this(year,brand, model, fuelCapasity, fuelFor1Km)
        {
            this.CurrentFuel = CurrentFuel;
        }
    }
}
