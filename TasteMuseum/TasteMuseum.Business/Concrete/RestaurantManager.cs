using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TasteMuseum.Business.Abstract;
using TasteMuseum.Business.Requests.Restaurant;
using TasteMuseum.Core.Expressions;
using TasteMuseum.DataAccess.Abstract;
using TasteMuseum.Entity.Concreate;

namespace TasteMuseum.Business.Concrete
{
    public class RestaurantManager : IRestaurantService
    {
        private readonly IRestaurantDal _restaurantDal;

        public RestaurantManager(IRestaurantDal restaurantDal)
        {
            _restaurantDal = restaurantDal;
        }

        public void AddRestaurant(AddRestaurantRequest request)
        {
            var restaurant = new Restaurant() { Name = request.Name ,Address = request.Address, PhoneNumber = request.PhoneNumber, Image = request.Image, OpeningHours = request.OpeningHours };
            _restaurantDal.Add(restaurant);  
        }

        public void DeleteRestaurantById(DeleteRestaurantByIdRequest request)
        {
            Restaurant? restaurant = _restaurantDal.Get(r=>r.Id == request.Id);
            if (restaurant == null)
            {
                throw new Exception("Restaurant not found");
            }
            _restaurantDal.Delete(restaurant);
        }


        public List<Restaurant> GetAllRestaurants(GetAllRestaurantsRequest request)
        {
            List<Restaurant>? restaurant = new List<Restaurant>();
            Expression <Func<Restaurant,bool>> expression = r =>true;
            if(request.MinRating != null)
            {
                expression = expression.ExAnd(r=>r.AverageRating>=request.MinRating);
            }
            if (request.Name != null)
            {
                expression = expression.ExAnd(r => r.Name.Contains(request.Name));
            }

            if (request.Address != null)
            {
                expression = expression.ExAnd(r => r.Address.Contains(request.Address));
            }
            restaurant=_restaurantDal.GetListAll(expression);
            if(restaurant == null || restaurant.Count==0) 
            {
                throw new Exception("No restaurant found");
            }
            return restaurant;
        }

        public Restaurant GetRestaurantById(GetRestaurantByIdRequest request)
        {
            Restaurant? restaurant = _restaurantDal.Get(r=>r.Id == request.Id, r=>r.Include(r=>r.RestaurantFood).Include(r=>r.RestaurantComments).ThenInclude(rc=>rc.User));
            
            if(restaurant == null)
            {
                throw new Exception("Restaurant not found by given id");
            }
            return restaurant;
        }

        public List<Restaurant> GetRestaurantsByAdress(GetRestaurantsByAdressRequest request)
        {
            List<Restaurant>? restaurant = _restaurantDal.GetListAll(r => r.Address == request.Adresss); 
            if(restaurant == null || restaurant.Count == 0) 
            {
                throw new Exception("No restaurant found by given adresss");
            }
            return restaurant;
        }
    }
}
