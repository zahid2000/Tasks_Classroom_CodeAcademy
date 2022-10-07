namespace Domain.Entities;

public class Category:BaseAuditableEntity
{
    public string CategoryName { get; set; } = null!;
}
