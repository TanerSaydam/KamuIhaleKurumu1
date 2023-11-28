namespace CleanArchitectureApp.Domain.Entities;

public sealed class Parent : Entity
{
    public string Name { get; set; }
    public string Lastname { get; set; }
    public string Kin { get; set; } //Aile Soydaş manasında
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}