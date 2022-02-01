using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoReceitas.Models
{
    public class TimeRecipe
    {
        public TimeRecipe()
        {

        }

        public TimeRecipe(int timeId, int recipeId)
        {

            this.TimeId = timeId;

            this.RecipeId = recipeId;

        }
        public int TimeId { get; set; }
        public int RecipeId { get; set; }
        public Time Time { get; set; }
        public Recipe Recipe { get; set; }
    }
}
