namespace ProjetoReceitas.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string PublicId { get; set; }

        public string ImageUrl { get; set; }

        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }
    }
}