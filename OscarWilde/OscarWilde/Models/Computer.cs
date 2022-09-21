namespace OscarWilde.Models
{
    public class Computer : IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
