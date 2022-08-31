using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_Lesson_Part2.Models;

public class Person
{
    public Person()
    {

    }
    public Person(int id, string name, string surname)
    {
        Id = id;
        Name = name;
        Surname = surname;
    }
    public override string ToString()
    {
        StringBuilder record = new StringBuilder();
        record.Append("Record { Id = " + Id + ", Name = " + Name + ", Surname = " + Surname + " }");

        return record.ToString();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
}
