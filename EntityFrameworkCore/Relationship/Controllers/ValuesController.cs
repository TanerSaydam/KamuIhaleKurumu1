using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Relationship.Context;
using Relationship.Models;

namespace Relationship.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ValuesController : ControllerBase
{
    private readonly AppDbContext _context;

    public ValuesController(AppDbContext context)
    {
        _context = context;
    }

    //[HttpGet]
    //public IActionResult Delete(int id)
    //{
    //    Category category = new() { Id = id };
    //    _context.Remove(category);
    //    _context.SaveChanges();
    //    return NoContent();
    //}

    [HttpGet]
    public async Task<IActionResult> GetUserById(int id)
    {
        Models.User user = await _context.Users.FindAsync(id);
        return Ok(user);
    }

    [HttpGet]
    public async Task<IActionResult> GetUserByIdCompiled(int id)
    {
        Models.User user = await _context.GetUserByIdCompiled(id);
        return Ok(user);
    }
}
