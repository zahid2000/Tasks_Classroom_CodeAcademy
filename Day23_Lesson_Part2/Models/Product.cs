namespace Day23_Lesson_Part2.Models
{
    public class Product
    {
        public int Id { get; set; }        
        public string ProductName { get; set; } = null!;
        public double Price { get; set; } 
        public DateTime RelaseDate { get; set; }
        public int Count { get; set; }  
    }
}
