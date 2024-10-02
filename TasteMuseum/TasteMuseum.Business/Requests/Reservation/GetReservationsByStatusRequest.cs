using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteMuseum.Entity.Concrete;

namespace TasteMuseum.Business.Requests.Reservation
{
    public class GetReservationsByStatusRequest
    {
        public ReservationStatus? Status {  get; set; }
    }
}
