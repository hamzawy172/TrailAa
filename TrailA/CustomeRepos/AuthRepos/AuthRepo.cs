using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TrailA.Data;
using TrailA.DTOs.AuthDtos;
using TrailA.GenericRepos;
using TrailA.Models;

namespace TrailA.CustomeRepos.AuthRepos
{
    public class AuthRepo : GenericRepo<User>, IAuthRepo
    {
        private readonly MyContext c;
        private readonly IConfiguration configuration;
        public AuthRepo(MyContext c , IConfiguration configuration) : base(c)
        {
            this.c = c;
            this.configuration = configuration;
        }

        public async Task<string> Login(LoginDto dto)
        {
            var data = await c.users.FirstOrDefaultAsync(a => a.Email == dto.Email);
            if (data == null)
            {
                return null;
            }
            if (data.Password == dto.Password)
            {
                return GenerateToken(data);
            }
            return null;
        }
        private string GenerateToken(User user)
        {
            var claimss = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier , user.Id.ToString()),
                new Claim(ClaimTypes.Name , user.FullName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["JWT:key"]));
            var signing = new SigningCredentials(key , SecurityAlgorithms.HmacSha256);
            var data = new JwtSecurityToken(
                issuer: configuration["JWT:issuer"],
                audience: configuration["JWT:audience"],
                expires: DateTime.Now.AddHours(6),
                signingCredentials: signing,
                claims: claimss);
            var token = new JwtSecurityTokenHandler().WriteToken(data);
            return token;
        }

        public async Task<bool> Register(User user)
        {
            var exi = await c.users.AnyAsync(a => a.Email == user.Email);
            if (exi)
            {
                return false;
            }
            await c.users.AddAsync(user);
            await c.SaveChangesAsync();
            return true;

        }

        public async Task<bool> eamilexi(string email)
        {
            var exi = await c.users.AnyAsync(a => a.Email == email);
            return exi;
        }
    }
}
