namespace Domain.Entities;

public abstract class BaseAuditableEntity:BaseEntity
{
    public string? CreatedBy { get; set; }
    public DateTime? CratedTime { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModifiedDate { get; set; }
}
