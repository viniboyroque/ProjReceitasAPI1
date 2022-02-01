using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoReceitas.Models
{
    public class Dificulty
    {
        public Dificulty()
        {

        }

        public Dificulty(int id, string name)
        {

            this.Id = id;
            this.Name = name;

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<DificultyRecipe> DificultiesRecipes { get; set; }
    }
}
