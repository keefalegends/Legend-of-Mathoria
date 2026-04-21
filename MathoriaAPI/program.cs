using Microsoft.EntityFrameworkCore;
using MathoriaAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("MathoriaDB"));

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }
    public DbSet<User> Users { get; set; }
}