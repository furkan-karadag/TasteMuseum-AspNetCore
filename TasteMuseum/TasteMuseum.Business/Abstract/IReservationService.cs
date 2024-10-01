using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteMuseum.Business.Requests.Reservation;
using TasteMuseum.Business.Requests.RestaurantComment;
using TasteMuseum.Entity.Concreate;
using TasteMuseum.Entity.Concrete;

namespace TasteMuseum.Business.Abstract
{
    public interface IReservationService
    {
        public void AddReservation(AddReservationRequest request);

        public List<Reservation> GetAllReservations(GetAllReservationsRequest request);
        public void DeleteReservation(DeleteReservationRequest request);
        List<Reservation> GetReservationsByStatus(GetReservationsByStatusRequest request);
    }
}
