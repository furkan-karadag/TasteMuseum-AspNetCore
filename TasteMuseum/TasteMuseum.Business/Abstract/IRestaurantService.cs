using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteMuseum.Business.Requests.Restaurant;
using TasteMuseum.Entity.Concreate;

namespace TasteMuseum.Business.Abstract
{
    public interface IRestaurantService
    {
        public void AddRestaurant(AddRestaurantRequest request);

        public Restaurant GetRestaurantById(GetRestaurantByIdRequest request);
        public List<Restaurant> GetRestaurantsByAdress(GetRestaurantsByAdressRequest request);
        public List<Restaurant> GetAllRestaurants(GetAllRestaurantsRequest request);

        public void DeleteRestaurantById(DeleteRestaurantByIdRequest request);
    }
}
