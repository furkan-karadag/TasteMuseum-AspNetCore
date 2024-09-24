using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasteMuseum.Business.Requests.Restaurant
{
    public class GetAllRestaurantsRequest
    {
        public int? MinRating { get; set; }
        public string? Address { get; set; }
        //public string? OpeningHours { get; set; }
        public string? Name { get; set; }
    }
}
