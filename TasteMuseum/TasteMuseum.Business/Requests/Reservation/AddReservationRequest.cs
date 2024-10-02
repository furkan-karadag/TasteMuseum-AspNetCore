using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteMuseum.Entity.Concrete;

namespace TasteMuseum.Business.Requests.Reservation
{
    public class AddReservationRequest
    {
        public DateTime Date { get; set; }
        public string PersonCount { get; set; }
        public int RestaurantId { get; set; }
        public int UserId { get; set; }
        public ReservationStatus? Status { get; set; } 
    }
    

}
