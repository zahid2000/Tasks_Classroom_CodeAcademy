namespace OscarWilde.Models
{
    public class Phone : IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string PhoneNumber { get; set; }

    }
}
