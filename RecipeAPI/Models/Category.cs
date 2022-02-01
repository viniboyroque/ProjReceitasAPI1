using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoReceitas.Models
{
    public class Category
    {
        public Category()
        {

        }

        public Category(int id, string name)
        {

            this.Id = id;
            this.Name = name;

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CategoryRecipe> CategoriesRecipes { get; set; }
    }
}
