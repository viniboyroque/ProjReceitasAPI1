using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProjetoReceitas.Data;
using ProjetoReceitas.Models;
using RecipeAPI.Dtos;

namespace ProjetoReceitas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IConfiguration configuration;
        public UsersController(IRepository repo, IConfiguration configuration)
        {
            this.configuration = configuration;
            _repo = repo;

        }

        // Authentication
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginReqDto loginReq)
        {
            var user = await _repo.Authenticate(loginReq.Name, loginReq.Password);

            if (user == null)
            {
                return Unauthorized("Invalid User Id or Password!");
            }

            var loginRes = new LoginResDto();
            loginRes.Id = user.Id;
            loginRes.Name = user.Name;
            loginRes.Token = CreateJWT(user);
            return Ok(loginRes);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterReq registerReq)
        {
            if (await _repo.UserAlreadyExists(registerReq.Name))
            return BadRequest("User already exists");

            _repo.Register(registerReq.Name, registerReq.Password, registerReq.Email);
            await _repo.SaveChangesAsync();
            return StatusCode(201);
        }

        //Generate JWT Token

        private string CreateJWT(User user)
        {
            var secretKey = configuration.GetSection("AppSettings:Key").Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var claims = new Claim[] {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())

            };

            var signingCredentials = new SigningCredentials(
                key, SecurityAlgorithms.HmacSha256Signature
            );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);


        }
        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            try
            {
                {
                    var result = await _repo.GetAllUsersAsync(true);
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex.Message}");
            }
        }

        // GET: api/Users/5
        [HttpGet("{UserId}")]
        public async Task<ActionResult<User>> GetByUserId(int UserId)
        {
            try
            {
                {
                    var result = await _repo.GetUserAsyncById(UserId, true);
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("ByRecipe/{recipeId}")]
        public async Task<IActionResult> GetByRecipeId(int recipeId)
        {
            try
            {
                var result = await _repo.GetUsersAsyncByRecipeId(recipeId, false);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex.Message}");
            }
        }
        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{UserId}")]
        public async Task<IActionResult> Put(int UserId, User userModel)
        {
            try
            {
                var user = await _repo.GetUserAsyncById(UserId, false);
                if (user == null) return NotFound();

                _repo.Update(userModel);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok(userModel);
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> Post(User userModel)
        {
            try
            {
                _repo.Add(userModel);
                if (await _repo.SaveChangesAsync())
                {
                    return Ok(userModel);
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

        // DELETE: api/Users/5
        [HttpDelete("{UserId}")]
        public async Task<IActionResult> Delete(int UserId)
        {
            try
            {
                var user = await _repo.GetUserAsyncById(UserId, false);
                if (user == null) return NotFound("User not found!");

                _repo.Delete(user);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok(new { message = "Deleted" });
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

        // private bool UserExists(int id)
        // {
        //     return _context.Users.Any(e => e.Id == id);
        // }
    }
}
