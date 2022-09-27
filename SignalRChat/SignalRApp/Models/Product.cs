using System.ComponentModel.DataAnnotations.Schema;

namespace SignalRApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public short UnitsInStock { get; set; }
        [Column(TypeName ="decimal(18,2)")]
        public decimal Price { get; set; }
    }
}
