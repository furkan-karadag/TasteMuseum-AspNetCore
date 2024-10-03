using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasteMuseum.Business.Requests.FoodComment
{
    public class AddFoodCommentRequest
    {
        public AddFoodCommentRequest() 
        {
            Date = DateTime.Now; 
        }
        public string Comment { get; set; }  
        public int Rating { get; set; } 
        public DateTime Date { get; set; }  
        public int FoodId { get; set; }
    }
}
