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
    if (users == null) return BadRequest();
    return Ok(users);
  }

  [HttpPost]
  public async Task<IActionResult> Post(User newUser)
  {
    _context.User.Add(newUser);
    await _context.SaveChangesAsync();
    return Ok(newUser);
  }


  [HttpDelete]
  public async Task<IActionResult> Delete(int id)
  {
    User? user = await _context.User.FindAsync(id);
    _context.User.Remove(user);
    await _context.SaveChangesAsync();
    return NoContent();
  }

  [HttpPut]
  public async Task<IActionResult> Put(User editedUser)
  {
    _context.Entry(editedUser).State = EntityState.Modified;
    await _context.SaveChangesAsync();
    return NoContent();
  }

}