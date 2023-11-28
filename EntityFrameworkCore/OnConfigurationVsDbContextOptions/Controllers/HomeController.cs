using Microsoft.AspNetCore.Mvc;
using OnConfigurationVsDbContextOptions.Context;

namespace OnConfigurationVsDbContextOptions.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetConnection()
    {
        //using ApplicationDbContext context = new();

        //context.Database.CanConnect();

        var result = _context.Database.CanConnect();

        return NoContent();
    }
}
