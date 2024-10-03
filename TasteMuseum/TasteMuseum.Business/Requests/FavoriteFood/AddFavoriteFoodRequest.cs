using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasteMuseum.Business.Requests.FavoriteFood
{
    public class AddFavoriteFoodRequest
    {
        public int UserId { get; set; }
        public int FoodId { get; set; }
    }
}
