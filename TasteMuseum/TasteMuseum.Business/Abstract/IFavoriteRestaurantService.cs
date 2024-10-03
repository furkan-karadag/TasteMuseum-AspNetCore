using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteMuseum.Entity.Concrete;

namespace TasteMuseum.Business.Abstract
{
    public interface IFavoriteRestaurantService
    {
        public void AddFavoriteRestaurant();
        public void RemoveFavoriteRestaurant();
        public List<FavoriteRestaurant> GetAllFavoriteRestaurants();
    }
}
