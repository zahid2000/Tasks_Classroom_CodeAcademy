using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_Lesson_Part1.StructModels
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string WriterName  { get; set; }
        public string BookName { get; set; }
        public int PageCount { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public  struct Kitab
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string WriterName { get; set; }
        public string BookName { get; set; }
        public int PageCount { get; set; }
        public DateTime CreatedDate { get; set; }   
    }
}
