using GameWebsiteAPI.Model;
using Microsoft.AspNetCore.Authorization;
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
    public class GameSellerLoginController : ControllerBase
    {
        public static GameSellerRegister gameSeller = new GameSellerRegister();
        private readonly IConfiguration _configuration;


        public GameSellerLoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("register")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<GameSellerRegister>> Register(GameSellerDto request)
        {
            CreatePasswordHash(request.GameSeller_password, out byte[] GameSeller_passwordHash, out byte[] GameSeller_passwordSalt);

            gameSeller.GameSeller_username = request.GameSeller_username;
            gameSeller.GameSeller_passwordHash = GameSeller_passwordHash;
            gameSeller.GameSeller_passwordSalt = GameSeller_passwordSalt;

            return Ok(gameSeller);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(GameSellerDto request)
        {
            if (gameSeller.GameSeller_username != request.GameSeller_username)
            {
                return BadRequest("Username not found.");
            }

            if (!VerifyPasswordHash(request.GameSeller_password, gameSeller.GameSeller_passwordHash, gameSeller.GameSeller_passwordSalt))
            {
                return BadRequest("Wrong password.");
            }

            string token = CreateToken(gameSeller);
            return Ok(token);
        }

        private string CreateToken(GameSellerRegister gameSeller)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, gameSeller.GameSeller_username),
                new Claim(ClaimTypes.Role, "GameSeller")
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
