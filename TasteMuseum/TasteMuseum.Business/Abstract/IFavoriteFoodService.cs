using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteMuseum.Entity.Concrete;

namespace TasteMuseum.Business.Abstract
{
    public interface IFavoriteFoodService
    {
        public void AddFavoriteFood();
        public void RemoveFavoriteFood();
        public List<FavoriteFood> GetAllFavoriteFoods();
    }
}
