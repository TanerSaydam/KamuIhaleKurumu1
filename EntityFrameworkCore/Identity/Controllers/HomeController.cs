using Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    public HomeController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        await _userManager.CreateAsync(new AppUser()
        {
            Id = Guid.NewGuid().ToString(),
            UserName = "tsaydam",
            Email = "tanersaydam@gmail.com",
            NameLastName = "Taner Saydam"
        },"Password12*");

        await _roleManager.CreateAsync(new IdentityRole()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Deneme"
        });

        await _userManager.CheckPasswordAsync(new AppUser(), "");

        return NoContent();
    }
}
