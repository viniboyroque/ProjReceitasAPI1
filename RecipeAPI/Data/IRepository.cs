using ProjetoReceitas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoReceitas.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //USER
        Task<User> Authenticate(string name, string password);

        void Register(string name, string password, string email);
        

        Task<bool> UserAlreadyExists(string name);
        Task<IEnumerable<User>> GetAllUsersAsync(bool includeRecipe);
        Task<User> GetUserAsyncById(int userId, bool includeRecipe);
        Task<User[]> GetUsersAsyncByRecipeId(int recipeId, bool includeRecipe);


        //RECIPE
        Task<IEnumerable<Recipe>> GetAllRecipesAsync(bool includeUser);
        Task<Recipe> GetRecipeAsyncById(int recipeId, bool includeUser);

        void AddRecipe(Recipe recipe);
        void DeleteRecipe(int id);

        Task<IEnumerable<Recipe>> GetRecipesAsyncByUserId(int userId, bool includeUser);
        Task<IEnumerable<Recipe>> GetRecipesAsyncByIngredientId(int ingredientId, bool includeIngredient);
      



    }
}
