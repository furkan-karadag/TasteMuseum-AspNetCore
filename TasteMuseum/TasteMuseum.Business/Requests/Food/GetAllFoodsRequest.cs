using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasteMuseum.Business.Requests.Food
{
    public class GetAllFoodsRequest
    {
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public int? MinRating { get; set; }
        public string? Name { get; set; }
    }
}
