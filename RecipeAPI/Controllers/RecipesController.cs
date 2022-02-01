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
    public class RecipesController : ControllerBase
    {
       private readonly IRepository _repo;
        public RecipesController(IRepository repo)
        {
            _repo = repo;

        }


        // GET: api/Recipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipe>>> Get()
        {
            try
            {
                {
                    var result = await _repo.GetAllRecipesAsync(true);
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex.Message}");
            }
        }

        // GET: api/Recipes/5
        [HttpGet("{RecipeId}")]
        public async Task<ActionResult<Recipe>> GetByRecipeId(int RecipeId)
        {
            try
            {
                {
                    var result = await _repo.GetRecipeAsyncById(RecipeId, true);
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("ByUser/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            try
            {
                var result = await _repo.GetRecipesAsyncByUserId(userId, false);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex.Message}");
            }
        }
        
        [HttpGet("ByIngredient/{ingredientId}")]
        public async Task<IActionResult> GetByIngredientId(int ingredientId)
        {
            try
            {
                var result = await _repo.GetRecipesAsyncByIngredientId(ingredientId, false);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex.Message}");
            }
        }

        

        
        // PUT: api/Recipes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{RecipeId}")]
        public async Task<IActionResult> Put(int RecipeId, Recipe recipeModel)
        {
            try
            {
                 var user = await _repo.GetRecipeAsyncById(RecipeId, false);
                 if(user == null) return NotFound();

                 _repo.Update(recipeModel);

                 if(await _repo.SaveChangesAsync())
                 {
                     return Ok(recipeModel);
                 }
            }
            catch (Exception ex)
            {
                
                return BadRequest ($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

        // POST: api/Recipes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Recipe>> Post(Recipe recipeModel)
        {
             try
            {
                 _repo.Add(recipeModel);
                 if(await _repo.SaveChangesAsync())
                 {
                     return Ok(recipeModel);
                 }
            }
            catch (Exception ex)
            {
                
                return BadRequest ($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

        // DELETE: api/Recipes/5
        [HttpDelete("{RecipeId}")]
        public async Task<IActionResult> Delete(int RecipeId)
        {
            try
            {
                 var recipe = await _repo.GetRecipeAsyncById(RecipeId, false);
                 if(recipe == null) return NotFound("Recipe not found!");

                 _repo.Delete(recipe);

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
