using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoReceitas.Models
{
    public class DificultyRecipe
    {
        public DificultyRecipe()
        {

        }

        public DificultyRecipe(int dificultyId, int recipeId)
        {

            this.DificultyId = dificultyId;

            this.RecipeId = recipeId;

        }
        public int DificultyId { get; set; }
        public int RecipeId { get; set; }
        public Dificulty Dificulty { get; set; }
        public Recipe Recipe { get; set; }
    }
}
