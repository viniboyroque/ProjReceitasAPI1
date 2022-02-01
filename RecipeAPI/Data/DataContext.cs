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
        public DbSet<UserRecipe> UserRecipes { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<IngredientRecipe> IngredientsRecipes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryRecipe> CategoriesRecipes { get; set; }
        public DbSet<Dificulty> Dificulties { get; set; }
        public DbSet<DificultyRecipe> DificultiesRecipes { get; set; }
        public DbSet<Time> Time { get; set; }
        public DbSet<TimeRecipe> TimesRecipes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserRecipe>()
                .HasKey(AD => new { AD.UserId, AD.RecipeId });
            builder.Entity<IngredientRecipe>()
                .HasKey(AD => new { AD.IngredientId, AD.RecipeId });
            builder.Entity<CategoryRecipe>()
                .HasKey(AD => new { AD.CategoryId, AD.RecipeId });
            builder.Entity<DificultyRecipe>()
                .HasKey(AD => new { AD.DificultyId, AD.RecipeId });
            builder.Entity<TimeRecipe>()
                .HasKey(AD => new { AD.TimeId, AD.RecipeId });
        }
    }
}
