using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        public async Task<User> Authenticate(string name, string passwordText)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Name == name);

            if (user == null || user.PasswordKey == null)
            return null;

            if(!MatchPasswordHash(passwordText, user.Password, user.PasswordKey))
            return null;

            return user;
        }

        private bool MatchPasswordHash(string passwordText, byte[] password, byte[] passwordKey)
        {
            using (var hmac = new HMACSHA512(passwordKey))
            {
                var passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(passwordText));

                for (int i=0; i<passwordHash.Length; i++)
                {
                    if (passwordHash[i] != password[i])
                    return false;
                }

                return true;
            }
        }

        public void Register(string name, string password, string email)
        {
            byte[] passwordHash, passwordKey;

            using (var hmac = new HMACSHA512())
            {
                passwordKey = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

            User user = new User();
            user.Name = name;
            user.Email = email;
            user.Password = passwordHash;
            user.PasswordKey = passwordKey;

            _context.Users.Add(user);
        }

        public async Task<bool> UserAlreadyExists(string name)
        {
            return await _context.Users.AnyAsync(x => x.Name == name);
        }
        public async Task<IEnumerable<User>> GetAllUsersAsync(bool includeRecipe = false)
        {
            var users = await _context.Users
            .Include(pe => pe.Recipe)
            .ToListAsync();
            return users;
            // IQueryable<Recipe> query = _context.Recipes;

            // if (includeUser)
            // {
            //     query = query.Include(pe => pe.UserId)
            //                 //  .ThenInclude(ad => ad.User)
            //                  ;
            // }

           

            // query = query.AsNoTracking()
            //              .OrderBy(c => c.Id);

            // return await query.ToArrayAsync();
        }
        public async Task<User> GetUserAsyncById(int userId, bool includeRecipe)
        {
            IQueryable<User> query = _context.Users;

            if (includeRecipe)
            {
                query = query.Include(pe => pe.Recipe)
                             .ThenInclude(ad => ad.UserId);
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
                query = query.Include(p => p.Recipe)
                             .ThenInclude(ad => ad.Id);
            }

            query = query.AsNoTracking()
                         .OrderBy(user => user.Id)
                        //  .Where(user => user.Recipes.Any(ad => ad.RecipeId == recipeId))
                         ;

            return await query.ToArrayAsync();
        }

        //RECIPE


        public void AddRecipe(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
        }

        public void DeleteRecipe(int id)
        {
            throw new System.NotImplementedException();
        }
        public async Task<IEnumerable<Recipe>> GetAllRecipesAsync(bool includeUser = false)
        {
            var recipes = await _context.Recipes
            .Include(pe => pe.Ingredients)
            .Include(pe => pe.User)
            .ToListAsync();
            return recipes;
            // IQueryable<Recipe> query = _context.Recipes;

            // if (includeUser)
            // {
            //     query = query.Include(pe => pe.UserId)
            //                 //  .ThenInclude(ad => ad.User)
            //                  ;
            // }

           

            // query = query.AsNoTracking()
            //              .OrderBy(c => c.Id);

            // return await query.ToArrayAsync();
        }
        public async Task<Recipe> GetRecipeAsyncById(int recipeId, bool includeUser)
        {
            var recipes = await _context.Recipes
                .Include(pe => pe.Ingredients)
                .Include(pe => pe.Photos)
                .Where(recipe => recipe.Id == recipeId)
                .FirstOrDefaultAsync();

                return recipes;
        }
        
        public async Task<IEnumerable<Recipe>> GetRecipesAsyncByUserId(int userId, bool includeUser)
        {
            IQueryable<Recipe> query = _context.Recipes;

            if (includeUser)
            {
                query = query.Include(p => p.UserId)
                            //  .ThenInclude(d => d.User)
                             ;
            }

            

            query = query.AsNoTracking()
                         .OrderBy(recipe => recipe.Id)
                        //  .Where(recipe => recipe.UserId.Any(ad => ad.UserId == userId))
                         ;

            return await query.ToArrayAsync();
        }
        public async Task<IEnumerable<Recipe>> GetRecipesAsyncByIngredientId(int ingredientId, bool includeIngredient)
        {
            IQueryable<Recipe> query = _context.Recipes;

            if (includeIngredient)
            {
                // query = query.Include(p => p.IngredientsRecipes)
                //              .ThenInclude(d => d.Ingredient);
            }

            // query = query.AsNoTracking()
            //              .OrderBy(recipe => recipe.Id)
            //              .Where(recipe => recipe.IngredientsRecipes.Any(ad => ad.IngredientId == ingredientId));

            return await query.ToArrayAsync();
        }

        
    }
}
