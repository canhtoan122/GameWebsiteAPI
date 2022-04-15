using GameWebsiteAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace GameWebsiteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminLoginController : ControllerBase
    {
        public static AdminRegister admin = new AdminRegister();
        private readonly IConfiguration _configuration;


        public AdminLoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AdminRegister>> Register(AdminDto request)
        {
            CreatePasswordHash(request.admin_password, out byte[] admin_passwordHash, out byte[] admin_passwordSalt);

            admin.admin_username = request.admin_username;
            admin.admin_passwordHash = admin_passwordHash;
            admin.admin_passwordSalt = admin_passwordSalt;

            return Ok(admin);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(AdminDto request)
        {
            if (admin.admin_username != request.admin_username)
            {
                return BadRequest("Username not found.");
            }

            if (!VerifyPasswordHash(request.admin_password, admin.admin_passwordHash, admin.admin_passwordSalt))
            {
                return BadRequest("Wrong password.");
            }

            string token = CreateToken(admin);
            return Ok(token);
        }

        private string CreateToken(AdminRegister admin)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, admin.admin_username),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
