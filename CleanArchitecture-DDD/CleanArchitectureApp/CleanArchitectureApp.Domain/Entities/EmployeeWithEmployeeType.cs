namespace CleanArchitectureApp.Domain.Entities;

public sealed class EmployeeWithEmployeeType
{
    public string EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public EmployeeType EmployeeType { get; set; }
}