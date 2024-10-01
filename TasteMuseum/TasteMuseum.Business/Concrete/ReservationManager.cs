using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TasteMuseum.Business.Abstract;
using TasteMuseum.Business.Requests.Reservation;
using TasteMuseum.Business.Requests.Restaurant;
using TasteMuseum.Core.Expressions;
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


        public List<Reservation> GetAllReservations(GetAllReservationsRequest request)
        {
            List<Reservation>? reservations = new List<Reservation>();
            Expression<Func<Reservation, bool>> expression = r => true;

            if (request.StartDate != null)
            {
                expression = expression.ExAnd(r => r.ReservationDate >= request.StartDate);
            }
            if (request.EndDate != null)
            {
                expression = expression.ExAnd(r => r.ReservationDate <= request.EndDate);
            }
            if (!string.IsNullOrEmpty(request.Status))
            {
                expression = expression.ExAnd(r => r.Status == request.Status);
            }
            if (request.UserId != null)
            {
                expression = expression.ExAnd(r => r.UserId == request.UserId);
            }
            if (request.RestaurantId != null)
            {
                expression = expression.ExAnd(r => r.RestaurantId == request.RestaurantId);
            }
            if (request.PersonCount != null)
            {
                expression = expression.ExAnd(r => r.PersonCount == request.PersonCount);
            }

            reservations = _reservationDal.GetListAll(expression);

            if (reservations == null || reservations.Count == 0)
            {
                throw new Exception("No reservations found");
            }
            return reservations;
        }

       

        public List<Reservation> GetReservationsByStatus(GetReservationsByStatusRequest request)
        {
            var reservations = _reservationDal.GetListAll(r => r.Status == request.Status);
            if (reservations == null || reservations.Count == 0)
            {
                throw new Exception("No reservations found with the given status.");
            }
            return reservations;
        }
    }
}
