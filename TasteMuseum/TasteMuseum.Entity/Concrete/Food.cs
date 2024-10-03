using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteMuseum.Entity.Concrete;

namespace TasteMuseum.Entity.Concreate
{
    public class Food
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }  
        public string Ingredients { get; set; }  // Malzemeler
        public string Recipe { get; set; }  // Tarif
        public double Price { get; set; }
        public double AverageRating { get; set; }
        public double RatingCount { get; set; }
        public string Image { get; set; }
        public int RestaurantId { get; set; }
        public List<RestaurantFood> RestaurantFood { get; set; } = new List<RestaurantFood>();
        public List<FoodComment> FoodComments { get; set; }
        public List<FavoriteFood> FavoriteFoods { get; set; } = new List<FavoriteFood>();
    }

}
