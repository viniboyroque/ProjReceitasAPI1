using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoReceitas.Models;

namespace ProjetoReceitas.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }


        //USER
        public async Task<User[]> GetAllUsersAsync(bool includeRecipe = false)
        {
            IQueryable<User> query = _context.Users;

            if (includeRecipe)
            {
                query = query.Include(pe => pe.UserRecipes)
                             .ThenInclude(ad => ad.Recipe);
            }

            query = query.AsNoTracking()
                         .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }
        public async Task<User> GetUserAsyncById(int userId, bool includeRecipe)
        {
            IQueryable<User> query = _context.Users;

            if (includeRecipe)
            {
                query = query.Include(pe => pe.UserRecipes)
                             .ThenInclude(ad => ad.Recipe);
            }

            query = query.AsNoTracking()
                         .OrderBy(user => user.Id)
                         .Where(user => user.Id == userId);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<User[]> GetUsersAsyncByRecipeId(int recipeId, bool includeRecipe)
        {
            IQueryable<User> query = _context.Users;

            if (includeRecipe)
            {
                query = query.Include(p => p.UserRecipes)
                             .ThenInclude(ad => ad.Recipe);
            }

            query = query.AsNoTracking()
                         .OrderBy(user => user.Id)
                         .Where(user => user.UserRecipes.Any(ad => ad.RecipeId == recipeId));

            return await query.ToArrayAsync();
        }

        //RECIPE
        public async Task<Recipe[]> GetAllRecipesAsync(bool includeUser = false)
        {
            IQueryable<Recipe> query = _context.Recipes;

            if (includeUser)
            {
                query = query.Include(pe => pe.UserRecipes)
                             .ThenInclude(ad => ad.User);
            }

            query = query.Include(ig => ig.DificultiesRecipes)
                         .ThenInclude(ad => ad.Dificulty);
                         
            query = query.Include(ig => ig.CategoriesRecipes)
                         .ThenInclude(ad => ad.Category);

            query = query.AsNoTracking()
                         .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Recipe> GetRecipeAsyncById(int recipeId, bool includeUser)
        {
            IQueryable<Recipe> query = _context.Recipes;

            if (includeUser)
            {
                query = query.Include(pe => pe.UserRecipes)
                             .ThenInclude(ad => ad.User);
            }
            
            query = query.Include(ig => ig.IngredientsRecipes)
                         .ThenInclude(ad => ad.Ingredient);

            query = query.Include(ig => ig.DificultiesRecipes)
                         .ThenInclude(ad => ad.Dificulty);
                         
            query = query.Include(ig => ig.CategoriesRecipes)
                         .ThenInclude(ad => ad.Category);
            

            query = query.AsNoTracking()
                         .OrderBy(recipe => recipe.Id)
                         .Where(recipe => recipe.Id == recipeId);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Recipe[]> GetRecipesAsyncByUserId(int userId, bool includeUser)
        {
            IQueryable<Recipe> query = _context.Recipes;

            if (includeUser)
            {
                query = query.Include(p => p.UserRecipes)
                             .ThenInclude(d => d.User);
            }

            query = query.Include(ig => ig.DificultiesRecipes)
                         .ThenInclude(ad => ad.Dificulty);
                         
            query = query.Include(ig => ig.CategoriesRecipes)
                         .ThenInclude(ad => ad.Category);

            query = query.AsNoTracking()
                         .OrderBy(recipe => recipe.Id)
                         .Where(recipe => recipe.UserRecipes.Any(ad => ad.UserId == userId));

            return await query.ToArrayAsync();
        }
        public async Task<Recipe[]> GetRecipesAsyncByIngredientId(int ingredientId, bool includeIngredient)
        {
            IQueryable<Recipe> query = _context.Recipes;

            if (includeIngredient)
            {
                query = query.Include(p => p.IngredientsRecipes)
                             .ThenInclude(d => d.Ingredient);
            }

            query = query.AsNoTracking()
                         .OrderBy(recipe => recipe.Id)
                         .Where(recipe => recipe.IngredientsRecipes.Any(ad => ad.IngredientId == ingredientId));

            return await query.ToArrayAsync();
        }
        public async Task<Recipe[]> GetRecipesAsyncByDificultyId(int dificultyId, bool includeDificulty)
        {
            IQueryable<Recipe> query = _context.Recipes;

            if (includeDificulty)
            {
                query = query.Include(p => p.DificultiesRecipes)
                             .ThenInclude(d => d.Dificulty);
            }

            query = query.AsNoTracking()
                         .OrderBy(recipe => recipe.Id)
                         .Where(recipe => recipe.DificultiesRecipes.Any(ad => ad.DificultyId == dificultyId));

            return await query.ToArrayAsync();
        }
        public async Task<Recipe[]> GetRecipesAsyncByCategoryId(int categoryId, bool includeCategory)
        {
            IQueryable<Recipe> query = _context.Recipes;

            if (includeCategory)
            {
                query = query.Include(p => p.CategoriesRecipes)
                             .ThenInclude(d => d.Category);
            }

            query = query.AsNoTracking()
                         .OrderBy(recipe => recipe.Id)
                         .Where(recipe => recipe.CategoriesRecipes.Any(ad => ad.CategoryId == categoryId));

            return await query.ToArrayAsync();
        }
        public async Task<Recipe[]> GetRecipesAsyncByTimeId(int timeId, bool includeTime)
        {
            IQueryable<Recipe> query = _context.Recipes;

            if (includeTime)
            {
                query = query.Include(p => p.TimesRecipes)
                             .ThenInclude(d => d.Time);
            }

            query = query.AsNoTracking()
                         .OrderBy(recipe => recipe.Id)
                         .Where(recipe => recipe.TimesRecipes.Any(ad => ad.TimeId == timeId));

            return await query.ToArrayAsync();
        }

    }
}
