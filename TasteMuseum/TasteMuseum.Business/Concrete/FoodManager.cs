using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TasteMuseum.Business.Abstract;
using TasteMuseum.Business.Requests.Food;
using TasteMuseum.DataAccess.Abstract;
using TasteMuseum.DataAccess.EntityFramework;
using TasteMuseum.DataAccess.Repository;
using TasteMuseum.Entity.Concreate;
using TasteMuseum.Core.Expressions;

namespace TasteMuseum.Business.Concrete
{
    public class FoodManager : IFoodService
    {
        private readonly IFoodDal _foodDal;

        public FoodManager(IFoodDal foodDal)
        {
            _foodDal = foodDal;
        }

        public void AddFood(AddFoodRequest request)
        {
            var food = new Food() { Name = request.Name, Ingredients = request.Ingredients, Recipe = request.Recipe, Price = request.Price, Image = request.Image, };
            _foodDal.Add(food);
        }

        public void DeleteFoodById(DeleteFoodByIdRequest request)
        {
            Food? food = _foodDal.Get(f => f.Id == request.Id);
            if (food == null)
            {
                throw new Exception("Food not found");
            }
            _foodDal.Delete(food);
        }

        public List<Food> GetAllFoods(GetAllFoodsRequest request)
        {
            List<Food>? food = new List<Food>();
            Expression<Func<Food, bool>> expression = f => true;

            if (request.MinPrice != null)
            {
                expression = expression.ExAnd(f => f.Price >= request.MinPrice);
            }
            if (request.MaxPrice != null)
            {
                expression = expression.ExAnd(f => f.Price <= request.MaxPrice);
            }
            if (request.MinRating != null)
            {
                expression = expression.ExAnd(f => f.AverageRating >= request.MinRating);
            }
            if (request.Name != null)
            {
                expression = expression.ExAnd(f => f.Name.Contains(request.Name));
            }

            food = _foodDal.GetListAll(expression);

            if (food == null || food.Count == 0)
            {
                throw new Exception("No food found");
            }
            return food;
        }

        public Food GetFoodById(GetFoodByIdRequest request)
        {
            Food? food = _foodDal.Get(f => f.Id == request.Id);
            if (food == null)
            {
                throw new Exception("Food not found by given id");
            }
            return food;
        }

        public List<Food> GetFoodsByPrice(GetFoodsByPriceRequest request)
        {
            List<Food>? food = _foodDal.GetListAll(f => f.Price == request.Price);
            if (food == null || food.Count == 0)
            {
                throw new Exception("No food found by given adresss");
            }
            return food;
        }
    }
}
