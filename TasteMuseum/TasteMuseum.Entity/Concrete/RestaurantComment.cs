using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasteMuseum.Entity.Concreate
{
    public class RestaurantComment
    {
        [Key]
        public int Id { get; set; }  
        public int RestaurantId { get; set; } 
        public Restaurant Restaurant { get; set; }
        public int UserId { get; set; }  
        public User User { get; set; }
        public string Comment { get; set; }  
        public double Rating { get; set; }  
        public DateTime Date { get; set; } 
    }

}
