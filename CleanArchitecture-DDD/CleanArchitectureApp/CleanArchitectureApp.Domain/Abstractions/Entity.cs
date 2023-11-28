namespace CleanArchitectureApp.Domain.Abstractions;

public abstract class Entity
{
    public Entity()
    {
        Id = Ulid.NewUlid().ToString();
        CreateDate = DateTime.Now;
        IsActive = true;
        IsDeleted = false;
    }

    public string Id { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreateDate { get; set; } //OccuredOn
    public DateTime? UpdateDate { get; set; }
}