using _01.MyFirstApi.Context;
using _01.MyFirstApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace _01.MyFirstApi.Controllers;

[ApiController]
[Route("api/[controller]")] //www.taner.com/api/Values/GetAll?name=Taner&age=33
public sealed class ValuesController : ControllerBase
{
    [HttpGet("GetAll")]
    public IActionResult GetAll(string name,int age)
    {
        return Ok(new {Message = "Api isteği başarılı"});
    }

    [HttpPost("Add")]
    public IActionResult Add(UserDto user)
    {
        return Ok(new { Message = "Api isteği başarılı" });
    }

    [HttpPut("Update")]
    public IActionResult Put()
    {
        return NoContent();
    }

    [HttpDelete("Delete")]
    public IActionResult Delete()
    {
        return NoContent();
    }
}

public sealed class User
{
    public string Name { get; set; }
    public int Age { get; set; }
}

public sealed class UserDto
{
    public User User { get; set; }
    public User User2 { get; set; }
}

