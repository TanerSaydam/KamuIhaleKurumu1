namespace KIKWebApi.Models;

public sealed class User : Entity
{
   public string UserName {  get; set; }
   public string NameLastName { get; set; }
   public string Password { get; set; }
   public string Email { get; set; }
   public string RefreshToken { get; set; }
   public DateTime RefreshTokenExpires { get; set; }
}
