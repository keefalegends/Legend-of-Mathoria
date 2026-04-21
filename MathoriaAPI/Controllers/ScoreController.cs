using Microsoft.AspNetCore.Mvc;
using MathoriaAPI.Models;

namespace MathoriaAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ScoreController : ControllerBase
{
    private readonly AppDbContext _context;

    public ScoreController(AppDbContext context)
    {
        _context = context;
    }

    // SAVE SCORE
    [HttpPost("save")]
    public IActionResult SaveScore([FromBody] User data)
    {
        var user = _context.Users.FirstOrDefault(u => u.Username == data.Username);

        if (user == null)
            return NotFound("User tidak ditemukan");

        user.Score = data.Score;
        _context.SaveChanges();

        return Ok(new { message = "Score tersimpan", score = user.Score });
    }

    // LEADERBOARD
    [HttpGet("leaderboard")]
    public IActionResult Leaderboard()
    {
        var top = _context.Users
            .OrderByDescending(u => u.Score)
            .Take(10)
            .Select(u => new { u.Username, u.Score })
            .ToList();

        return Ok(top);
    }
}