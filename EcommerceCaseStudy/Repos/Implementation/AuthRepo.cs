using EcommerceCaseStudy.Data;
using EcommerceCaseStudy.DTO.Auth;
using EcommerceCaseStudy.Models;
using EcommerceCaseStudy.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EcommerceCaseStudy.Repos.Implementation
{
    public class AuthRepo : IAuthRepo
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _conf;
        public AuthRepo(AppDbContext context, IConfiguration conf)
        {
            _context = context;
            _conf = conf;
        }
        public async Task<string> Login(LoginDTO dto)
        {
            var u = await _context.users.FirstOrDefaultAsync(c => c.Email == dto.Email);
            if (u == null) { return null; }

            if (u.Password == dto.Password)
            {
                return GenerateToken(u);
            }

            return null;
        }

        public async Task<bool> Register(RegisterDTO dto)
        {
           var u=await _context.users.AnyAsync(c=>c.Email==dto.Email);

            if (u) { return false; }

            var user = new User
            {
                Email = dto.Email,
                Password = dto.Password,
                Role = dto.Role,
                FullName = dto.FullName,
            };

            _context.users.Add(user);
            _context.SaveChanges();
            return true;
        }

        private string GenerateToken(User user)
        {
            var claim = new List<Claim> { 
            
                new Claim(ClaimTypes.Name,user.FullName),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,user.Role)
            
            };
            var Key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_conf["JWT:Key"]));
            var sinig = new SigningCredentials(Key,SecurityAlgorithms.HmacSha256);
            var tokenObj = new JwtSecurityToken(

                issuer: _conf["JWT:Issuer"],
                audience: _conf["JWT:Audience"],
                expires: DateTime.UtcNow.AddHours(Convert.ToDouble(_conf["JWT:ExpirationInHours"])),
                claims:claim,
                signingCredentials:sinig
                );

            var token =new JwtSecurityTokenHandler().WriteToken(tokenObj);
            return token;
        }
    }
}
