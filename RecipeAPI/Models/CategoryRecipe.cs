using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoReceitas.Models
{
    public class CategoryRecipe
    {
        public CategoryRecipe()
        {

        }

        public CategoryRecipe(int categoryId, int recipeId)
        {

            this.CategoryId = categoryId;

            this.RecipeId = recipeId;

        }
        public int CategoryId { get; set; }
        public int RecipeId { get; set; }
        public Category Category { get; set; }
        public Recipe Recipe { get; set; }
    }
}
