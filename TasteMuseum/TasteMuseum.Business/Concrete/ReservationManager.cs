using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TasteMuseum.Business.Abstract;
using TasteMuseum.Business.Requests.Reservation;
using TasteMuseum.Business.Requests.Restaurant;
using TasteMuseum.DataAccess.Abstract;
using TasteMuseum.Entity.Concrete;

namespace TasteMuseum.Business.Concrete
{
    public class ReservationManager : IReservationService
    {
        private readonly IReservationDal _reservationDal;
        private readonly IRestaurantService _restaurantService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ReservationManager(IReservationDal reservationDal, IRestaurantService restaurantService, IHttpContextAccessor httpContextAccessor)
        {
            _reservationDal = reservationDal;
            _restaurantService = restaurantService;
            _httpContextAccessor = httpContextAccessor;
        }


        public void AddReservation(AddReservationRequest request)
        {
            
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                throw new Exception("User must be logged in to make a reservation.");
            }

            
            var restaurant = _restaurantService.GetRestaurantById(new GetRestaurantByIdRequest { Id = request.RestaurantId });
            if (restaurant == null)
            {
                throw new Exception("Restaurant not found.");
            }
                

           
            var reservation = new Reservation { UserId=int.Parse(userId) ,RestaurantId=request.RestaurantId,PersonCount=request.PersonCount,ReservationDate=request.Date,Status=request.Status};
            

            _reservationDal.Add(reservation);
        }

        public void DeleteReservation(DeleteReservationRequest request)
        {
            var reservation = _reservationDal.Get(r => r.Id == request.Id);
            if (reservation != null)
            {
                _reservationDal.Delete(reservation);
            }
            else
            {
                throw new Exception("Reservation not found.");
            }
        }

        public List<Reservation> GetAllReservations()
        {
            List<Reservation> reservations = _reservationDal.GetListAll();
            if (reservations==null || reservations.Count == 0)
            {
                throw new Exception("No Reservations found");
            }
            return reservations;
        }

        public List<Reservation> GetReservationsByStatus(string status)
        {
            var reservations = _reservationDal.GetListAll(r => r.Status == status);
            if (reservations == null || reservations.Count == 0)
            {
                throw new Exception("No reservations found with the given status.");
            }
            return reservations;
        }

    }
}
