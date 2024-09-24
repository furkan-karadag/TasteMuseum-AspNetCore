using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TasteMuseum.Business.Abstract;
using TasteMuseum.Business.Requests.Reservation;

namespace TasteMuseum.Controllers
{
    [Authorize]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public IActionResult AddReservation(AddReservationRequest request)
        {
            try
            {
                _reservationService.AddReservation(request);
                return RedirectToAction("MyReservations");
            }
            catch (Exception ex)
            {
                // Handle errors
                return BadRequest(ex.Message);
            }
        }

        public IActionResult MyReservations(string status = "Pending Approval")
        {
            var reservations = _reservationService.GetReservationsByStatus(status);
            return View(reservations);
        }

        public IActionResult DeleteReservation(int id)
        {
            try
            {
                _reservationService.DeleteReservation(new DeleteReservationRequest { Id = id });
                return RedirectToAction("MyReservations");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
