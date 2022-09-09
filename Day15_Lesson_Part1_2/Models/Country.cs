using System;
namespace Day15_Lesson_Part1_2.Models;
public class Country{

    public Country()
    {
        Id=Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string ISO { get; set; }
    public string Capital { get; set; }
    public string Currency { get; set; }
    public string Continent { get; set; }
    public string Property { get; set; }
    
    
    
    
    
    
    
}