namespace CleanArchitectureApp.Domain.Entities;

public sealed class Student : Entity
{
    public string Name { get; set; }
    public string Lastname { get; set; }
    public DateTime DateOfBirtday { get; set; }
    public string Class { get; set; }
    public int No { get; set; }
}