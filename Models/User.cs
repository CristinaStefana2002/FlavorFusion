using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.ComponentModel.DataAnnotations;

namespace FlavorFusion.Models
{
    public class User
    {
        public int Id { get; set; }
        [RegularExpression(@"^[A-Z]+[a-z\s]*$")]
        [StringLength(30, MinimumLength = 3)]
        public string UserName { get; set; }
        public string Email { get; set; }
        public ICollection<Recipe> Recipes { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }

}