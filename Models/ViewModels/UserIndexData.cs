using FlavorFusion.Models;

namespace FlavorFusion.Models.ViewModels
{
    public class UserIndexData
    {
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Recipe> Recipes { get; set; }
    }
}
