using Microsoft.AspNetCore.Mvc;
using PMT.Application.DTOs;
using PMT.Application.Services;
using PMT.Domain.Entities;
using PMT.Infrastructure.Data;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly AuthService _auth;

    public AuthController(AppDbContext context, AuthService auth)
    {
        _context = context;
        _auth = auth;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        // ✅ VALIDATION (IMPORTANT)
        var allowedRoles = new[] { "Admin", "Manager", "User" };

        if (!allowedRoles.Contains(dto.Role))
            return BadRequest("Invalid role");

        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),

            // 🔥 ROLE FROM DTO
            Role = dto.Role
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpPost("login")]
    public IActionResult Login(LoginDto dto)
    {
        var user = _context.Users
            .FirstOrDefault(u => u.Email == dto.Email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            return Unauthorized();

        var token = _auth.GenerateToken(user);

        return Ok(new { token });
    }
}