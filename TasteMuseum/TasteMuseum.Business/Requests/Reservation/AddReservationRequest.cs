using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasteMuseum.Business.Requests.Reservation
{
    public class AddReservationRequest
    {
        public DateTime Date { get; set; }
        public string PersonCount { get; set; }
        public int RestaurantId { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; } 
    }
    public enum Status
    {
        PendingApproval,
        Approved,
        Declined,
        Completed
    }

}
