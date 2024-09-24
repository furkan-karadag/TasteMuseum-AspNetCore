using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasteMuseum.Entity.Concreate
{
    public class RestaurantFood
    {
       
        public int RestaurantId { get; set; } 
        public Restaurant Restaurant { get; set; }

        public int FoodId { get; set; }  
        public Food Food { get; set; }
    }

}
