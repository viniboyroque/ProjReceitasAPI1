using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoReceitas.Models
{
    public class IngredientRecipe
    {
        public IngredientRecipe()
        {

        }

        public IngredientRecipe(int ingredientId, int recipeId)
        {

            this.IngredientId = ingredientId;

            this.RecipeId = recipeId;

        }
        public int IngredientId { get; set; }
        public int RecipeId { get; set; }
        public Ingredient Ingredient { get; set; }
        public Recipe Recipe { get; set; }
    }
}
