using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_Lesson_Part2.Models
{
    public class Room
    {
        private static int id=0;

        public Room(string name,double price,int personCapacity)
        {
          
            Name = name;
            Price = price;
            PersonCapacity = personCapacity;
            id++;
            Id = id;
        }
        public Room(string name, double price, int personCapacity,bool isAviable):this(name,price,personCapacity)
        {
            
            IsAviable=isAviable;
        }
        public int Id { get;   }
        public string Name { get; set; }
        public double Price { get; set; }
        public int PersonCapacity { get; set; }
        public bool IsAviable { get; set; }=true;
        public string ShowInfo() => $"Id : {Id} , Name : {Name} , Price : {Price} , PersonCapacity : {PersonCapacity} , IsAviable : {IsAviable}";
        public override string ToString()
        {
            return ShowInfo();
        }
    }
}
