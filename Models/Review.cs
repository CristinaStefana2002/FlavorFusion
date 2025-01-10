namespace FlavorFusion.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; } // 1 - 5 stele
        public Recipe Recipe { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }

}