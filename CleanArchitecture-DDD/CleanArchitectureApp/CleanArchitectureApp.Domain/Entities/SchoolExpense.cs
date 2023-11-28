namespace CleanArchitectureApp.Domain.Entities;

public sealed class SchoolExpense : Entity
{
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string InvoiceNumber { get; set; }

    public string EmployeeId { get; set; }
    public Employee Employee { get; set; }
}