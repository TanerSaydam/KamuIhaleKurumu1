namespace KIKWebApi.Models;

public sealed class Personel : Entity
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Profession { get; set; }
    public string ImageUrl { get; set; }
    public decimal Salary { get; set; }
    public DateTime StartingDate { get; set; }
    public DateTime? LeavingDate { get; set; }
    public string LeavingStatus { get; set; }
}
