using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoReceitas.Models
{
    public class UserRecipe
    {
        public UserRecipe()
        {

        }

        public UserRecipe(int userId, int recipeId)
        {

            this.UserId = userId;

            this.RecipeId = recipeId;

        }
        public int UserId { get; set; }
        public int RecipeId { get; set; }
        public User User { get; set; }
        public Recipe Recipe { get; set; }
    }
}
