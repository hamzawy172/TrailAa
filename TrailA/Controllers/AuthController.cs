using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrailA.DTOs.AuthDtos;
using TrailA.Models;
using TrailA.UnitOfWorks;

namespace TrailA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork u;
        public AuthController(IUnitOfWork u)
        {
            this.u = u;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var data = await u.Auth.Login(dto);
            if (data == null)
            {
                return Unauthorized();
            }
            return Ok(data);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Rigster(RegisterDto dto)
        {
            var exi = await u.Auth.eamilexi(dto.Email);
            if (exi)
            {
                return BadRequest("Email must be unique");
            }
            if (dto == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var data = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Password = dto.Password,
                Role = dto.Role,
                CreatedAt = dto.CreatedAt
            };

            if (dto.Role == "Admin")
            {
                return BadRequest("Cant register as admin");
            }
            await u.Auth.Register(data);
            return Created();
        }
    }
}
