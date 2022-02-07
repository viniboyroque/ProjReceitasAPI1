using Microsoft.EntityFrameworkCore;
using ProjetoReceitas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoReceitas.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        // public DbSet<UserRecipe> UserRecipes { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        // public DbSet<Photo> Photos { get; set; }
        // public DbSet<IngredientRecipe> IngredientsRecipes { get; set; }
        

        // protected override void OnModelCreating(ModelBuilder builder)
        // {
           
        //     builder.Entity<IngredientRecipe>()
        //         .HasKey(AD => new { AD.IngredientId, AD.RecipeId });
            
        // }
    }
}
