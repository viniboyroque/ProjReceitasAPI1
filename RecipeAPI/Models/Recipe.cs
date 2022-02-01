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
        public Recipe(int id, string title, string recipebody, string difficulty, string category, string time)
        {

            this.Id = id;
            this.Title = title;
            this.RecipeBody = recipebody;
            this.Difficulty = difficulty;
            this.Category = category;
            this.Time = time;

        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string RecipeBody { get; set; }

        public string Difficulty { get; set; }

        public string Category { get; set; }

        public string Time { get; set; }

        //public int UserId { get; set; }
        //public User User { get; set; }
        public IEnumerable<UserRecipe> UserRecipes { get; set; }
        public IEnumerable<IngredientRecipe> IngredientsRecipes { get; set; }
        

    }
}
