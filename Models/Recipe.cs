using System.ComponentModel.DataAnnotations.Schema;

namespace FlavorFusion.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Instructions { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int UserId { get; set; } 
        public User User { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public string ImageUrl { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public int? MealPlanId { get; set; }
        public MealPlan MealPlan { get; set; }

    }

}