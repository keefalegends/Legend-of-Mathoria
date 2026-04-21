using Microsoft.AspNetCore.Mvc;
using MathoriaAPI.Models;

namespace MathoriaAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;

    public AuthController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("register")]
    public IActionResult Register(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();

        return Ok(new { message = "Register berhasil" });
    }

    [HttpPost("login")]
    public IActionResult Login(User login)
    {
        var user = _context.Users
            .FirstOrDefault(u => u.Username == login.Username 
                              && u.Password == login.Password);

        if (user == null)
            return Unauthorized("Login gagal");

        return Ok(new { message = "Login berhasil" });
    }
}