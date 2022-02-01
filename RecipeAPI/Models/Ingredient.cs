using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoReceitas.Models
{
    public class Ingredient
    {
        public Ingredient()
        {

        }

        public Ingredient(int id, string name, string quantity)
        {

            this.Id = id;
            this.Name = name;
            this.Quantity = quantity;

        }

        public int Id { get; set; }
        public string Name { get; set; }

        public string Quantity { get; set; }
        public IEnumerable<IngredientRecipe> IngredientsRecipes { get; set; }
    }
}
