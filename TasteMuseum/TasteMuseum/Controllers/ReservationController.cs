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
        [HttpGet("Index")]
        public IActionResult Index([FromQuery] GetAllReservationsRequest request)
        {
            try 
            {
                var reservations = _reservationService.GetAllReservations(request);
                return Ok(reservations);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpPost("AddReservation")]
        public IActionResult AddReservation(AddReservationRequest request)
        {
            try
            {
                _reservationService.AddReservation(request);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetReservationsByStatus")]
        public IActionResult GetReservationsByStatus(GetReservationsByStatusRequest request )
        {
            try
            {
                 var reservations=_reservationService.GetReservationsByStatus(request);
                return Ok(reservations);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteReservation")]
        public IActionResult DeleteReservation(DeleteReservationRequest request)
        {
            try
            {
                _reservationService.DeleteReservation(request);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
