using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteMuseum.Entity.Concrete;

namespace TasteMuseum.Business.Requests.Reservation
{
    public class GetAllReservationsRequest
    {
        public DateTime? StartDate { get; set; }  
        public DateTime? EndDate { get; set; } 
        public ReservationStatus? Status { get; set; }  // Rezervasyon durumu (pending, approved, past)
        public int? UserId { get; set; }  
        public int? RestaurantId { get; set; } 
        public string? PersonCount { get; set; }  
    }
}
