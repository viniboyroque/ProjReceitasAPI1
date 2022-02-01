using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoReceitas.Models
{
    public class User
    {
        public User()
        {

        }

        public User(int id, string name, string email, string password)
        {

            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Password = password;

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IEnumerable<UserRecipe> UserRecipes { get; set; }
    }

}
