using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoReceitas.Models
{
    public class Recipe
    {
        public Recipe()
        {

        }
        public Recipe(int id, string title, string recipebody)
        {

            this.Id = id;
            this.Title = title;
            this.RecipeBody = recipebody;

        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string RecipeBody { get; set; }

        //public int UserId { get; set; }
        //public User User { get; set; }
        public IEnumerable<UserRecipe> UserRecipes { get; set; }
        public IEnumerable<IngredientRecipe> IngredientsRecipes { get; set; }
        public IEnumerable<CategoryRecipe> CategoriesRecipes { get; set; }
        public IEnumerable<DificultyRecipe> DificultiesRecipes { get; set; }
        public IEnumerable<TimeRecipe> TimesRecipes { get; set; }

    }
}
