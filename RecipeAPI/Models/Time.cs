using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoReceitas.Models
{
    public class Time
    {
        public Time()
        {

        }

        public Time(int id, string name)
        {

            this.Id = id;
            this.Name = name;

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<TimeRecipe> TimesRecipes { get; set; }
    }
}
