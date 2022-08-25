using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_Tasks.Models
{
    public class Entity
    {
        public int Id { get; set; }
    }
    public class Person:Entity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
    public  partial class Category : Entity
    {
        public string CategoryName { get; set; } = null!;
    }
}
