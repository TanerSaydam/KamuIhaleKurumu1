namespace KIKWebApi.DTOs;

public class CreatePersonelDto
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Profession { get; set; }
    public decimal Salary { get; set; }
    public DateTime StartingDate { get; set; }
    public DateTime? LeavingDate { get; set;}
    public string? LeavingStatus{ get; set;}
}

public sealed class CreatePersonelWithFileDto : CreatePersonelDto
{
    public IFormFile Image { get; set; }    
}
