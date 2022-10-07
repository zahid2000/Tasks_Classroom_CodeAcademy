namespace Domain.Entities;

public class Product:BaseAuditableEntity
{
    public string ProductName { get; set; } = null!;
    public double UnitPrice { get; set; }
    public int UnitsInStock { get; set; }
    public int CategoryId { get; set; }

}
