using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using usersApi.Models;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
  private readonly UsersAPIContext _context;

  public UserController(UsersAPIContext context)
  {
    _context = context;
  }

  [HttpGet]
  public async Task<IActionResult> Get()
  {
    List<User> users = await _context.User.ToListAsync();
    if(users == null) return BadRequest();
    return Ok(users);
  }
}