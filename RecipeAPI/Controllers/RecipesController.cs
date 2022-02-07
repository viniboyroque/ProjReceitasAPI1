using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoReceitas.Data;
using ProjetoReceitas.Models;
using RecipeAPI.Data;

namespace ProjetoReceitas.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IPhotoService photoService;
        public RecipesController(IRepository repo, IPhotoService photoService)
        {
            this.photoService = photoService;
            _repo = repo;

        }


        // GET: api/Recipes
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> Get()
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
        [AllowAnonymous]
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
                if (user == null) return NotFound();

                _repo.Update(recipeModel);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok(recipeModel);
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

        // POST: api/Recipes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post(Recipe recipeModel)
        {


            _repo.AddRecipe(recipeModel);
            await _repo.SaveChangesAsync();
            return StatusCode(201);
        }

        // DELETE: api/Recipes/5
        [HttpDelete("{RecipeId}")]
        public async Task<IActionResult> Delete(int RecipeId)
        {
            try
            {
                var recipe = await _repo.GetRecipeAsyncById(RecipeId, false);
                if (recipe == null) return NotFound("Recipe not found!");

                _repo.Delete(recipe);

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

        [HttpPost("photo/{recipeId}")]
        [AllowAnonymous]
        public async Task<ActionResult> PostPhoto(IFormFile file, int recipeId)
        {
            var result = await photoService.UploadPhotoAsync(file);
            if(result.Error != null)
                return BadRequest(result.Error.Message);
            var recipe = await _repo.GetRecipeAsyncById(recipeId, false);

            var photo = new Photo
            {
                ImageUrl = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };
            
            recipe.Photos.Add(photo);
            await _repo.SaveChangesAsync();

            return Ok(201);
            
        }
    }
}
