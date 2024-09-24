using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasteMuseum.Business.Requests.Food
{
    public class AddFoodRequest
    {
        public string Name { get; set; }
        public string Ingredients { get; set; }  // Malzemeler
        public string Recipe { get; set; }  // Tarif
        public double Price { get; set; }
        public string Image { get; set; }
    }
}
