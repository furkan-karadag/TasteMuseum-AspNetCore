using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasteMuseum.Business.Requests.RestaurantComment
{
    public class AddRestaurantCommentRequest
    {
        public AddRestaurantCommentRequest()
        {
            Date= DateTime.Now;
        }
       
        public DateTime Date { get; }
        public string Comment { get; set; }
        public double Rating { get; set; }
        public int RestaurantId { get; set; }
    }
}
