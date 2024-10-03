using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteMuseum.Entity.Concrete;

namespace TasteMuseum.Entity.Concreate
{
    public class User : IdentityUser<int>
    {
        [Key]
        public override int Id { get => base.Id; set => base.Id = value; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public override string Email { get => base.Email; set => base.Email = value; }
        public string? Image { get; set; }
        public override string UserName { get => base.UserName; set => base.UserName = value; }
        public List<RestaurantComment> RestaurantComments { get; set; }
        public List<FoodComment> FoodComments { get; set; }
        public List <Reservation> Reservations { get; set; }
        public List<FavoriteRestaurant> FavoriteRestaurants { get; set; } = new List<FavoriteRestaurant>();
        public List<FavoriteFood> FavoriteFoods { get; set; } = new List<FavoriteFood>();
    }

}
