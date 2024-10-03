using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasteMuseum.Business.Requests.FavoriteRestaurant
{
    public class RemoveFavoriteRestaurantRequest
    {
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
    }
}
