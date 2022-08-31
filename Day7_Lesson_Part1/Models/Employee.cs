using Day7_Lesson_Part1.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7_Lesson_Part1.Models
{
    public class Entity
    {
        [ColumnName("HomeAddress")]
        public string  Address { get; set; }
    }
    public class Employee:Entity
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Bu alan bos gecilemz")]
        [Display(Name ="Adl")]
        public string FirstName { get; set; }

        [

            Required,
            Display(Name ="Soyadi")
]
        public string LastName { get; set; }
        [ColumnName]
        public string Email { get; set; }
        [ColumnName("WorkPhone")]
        public string Phone { get; set; }
    }
}
