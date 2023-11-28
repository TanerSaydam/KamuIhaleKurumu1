namespace CleanArchitectureApp.Domain.Entities;

public sealed class StudentParent
{
    public string StudentId { get; set; }
    public Student Student { get; set; }
    public string ParentId { get; set; }
    public Parent Parent { get; set; }
}