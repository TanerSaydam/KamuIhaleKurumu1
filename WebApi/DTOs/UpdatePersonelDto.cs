namespace KIKWebApi.DTOs;

public class UpdatePersonelDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Profession { get; set; }
    public decimal Salary { get; set; }
    public DateTime StartingDate { get; set; }
    public DateTime? LeavingDate { get; set; }
    public string? LeavingStatus { get; set; }
}