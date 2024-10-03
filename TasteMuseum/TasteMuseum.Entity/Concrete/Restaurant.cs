using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteMuseum.Entity.Concrete;

namespace TasteMuseum.Entity.Concreate
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }  
        public string Name { get; set; }  
        public string Address { get; set; }  
        public string PhoneNumber { get; set; } 
        public string OpeningHours { get; set; }  
      
        public double AverageRating { get; set; }
        public double RatingCount { get; set; }
        public string Image {  get; set; }

        public List<RestaurantFood> RestaurantFood { get; set; } = new List<RestaurantFood>();
  
        public List<RestaurantComment> RestaurantComments { get; set; }

        public List<Reservation> Reservations { get; set; }
        public List<FavoriteRestaurant> FavoriteRestaurants { get; set; } = new List<FavoriteRestaurant>();
    }

}
