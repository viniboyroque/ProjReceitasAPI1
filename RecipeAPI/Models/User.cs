using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoReceitas.Models
{
    public class User
    {
        public User()
        {

        }

        public User(int id, string name, string email, byte[] password)
        {

            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Password = password;

        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        [Required]
        public byte[] Password { get; set; }

        public byte[] PasswordKey { get; set; }

        public Recipe Recipe { get; set; }
        // public IEnumerable<UserRecipe> UserRecipes { get; set; }
    }

}
