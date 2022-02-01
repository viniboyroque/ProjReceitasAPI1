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
        Task<User[]> GetAllUsersAsync(bool includeRecipe);
        Task<User> GetUserAsyncById(int userId, bool includeRecipe);
        Task<User[]> GetUsersAsyncByRecipeId(int recipeId, bool includeRecipe);


        //RECIPE
        Task<Recipe[]> GetAllRecipesAsync(bool includeUser);
        Task<Recipe> GetRecipeAsyncById(int recipeId, bool includeUser);
        Task<Recipe[]> GetRecipesAsyncByUserId(int userId, bool includeUser);
        Task<Recipe[]> GetRecipesAsyncByIngredientId(int ingredientId, bool includeIngredient);
        Task<Recipe[]> GetRecipesAsyncByDificultyId(int dificultyId, bool includeDificulty);
        Task<Recipe[]> GetRecipesAsyncByCategoryId(int categoryId, bool includeCategory);
        Task<Recipe[]> GetRecipesAsyncByTimeId(int timeId, bool includeTime);



    }
}
