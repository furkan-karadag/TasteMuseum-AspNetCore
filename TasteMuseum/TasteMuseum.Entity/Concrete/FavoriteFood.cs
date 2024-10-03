using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteMuseum.Entity.Concreate;

namespace TasteMuseum.Entity.Concrete
{
    public class FavoriteFood
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FoodId { get; set; }
        public User User { get; set; }
        public Food Food { get; set; }
    }
}
