using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteMuseum.Business.Requests.Food;
using TasteMuseum.Entity.Concreate;

namespace TasteMuseum.Business.Abstract
{
    public interface IFoodService
    {
        public void AddFood(AddFoodRequest request);
        public Food GetFoodById(GetFoodByIdRequest request);

        public List<Food> GetFoodsByPrice(GetFoodsByPriceRequest request);
        public List<Food> GetAllFoods(GetAllFoodsRequest request);

        public void DeleteFoodById(DeleteFoodByIdRequest request);

    }
}
