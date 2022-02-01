using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoReceitas.Data;
using ProjetoReceitas.Models;

namespace ProjetoReceitas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepository _repo;
        public UsersController(IRepository repo)
        {
            _repo = repo;

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
                 if(user == null) return NotFound();

                 _repo.Update(userModel);

                 if(await _repo.SaveChangesAsync())
                 {
                     return Ok(userModel);
                 }
            }
            catch (Exception ex)
            {
                
                return BadRequest ($"Erro: {ex.Message}");
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
                 if(await _repo.SaveChangesAsync())
                 {
                     return Ok(userModel);
                 }
            }
            catch (Exception ex)
            {
                
                return BadRequest ($"Erro: {ex.Message}");
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
                 if(user == null) return NotFound("User not found!");

                 _repo.Delete(user);

                 if(await _repo.SaveChangesAsync())
                 {
                     return Ok(new {message = "Deleted"});
                 }
            }
            catch (Exception ex)
            {
                
                return BadRequest ($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

        // private bool UserExists(int id)
        // {
        //     return _context.Users.Any(e => e.Id == id);
        // }
    }
}
