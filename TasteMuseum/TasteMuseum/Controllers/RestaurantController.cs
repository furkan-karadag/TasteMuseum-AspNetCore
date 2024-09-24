using Microsoft.AspNetCore.Mvc;
using TasteMuseum.Business.Abstract;
using TasteMuseum.Business.Requests.Restaurant;
using TasteMuseum.Entity.Concreate;

namespace TasteMuseum.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantController : Controller
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController (IRestaurantService restaurantservice)
        {
            _restaurantService = restaurantservice;
        }
        [HttpGet("GetRestaurantsByAdress")]
        public IActionResult GetRestaurantsByAdress(GetRestaurantsByAdressRequest request)
        {
            try
            {
                var restaurants = _restaurantService.GetRestaurantsByAdress(request);
                return Ok(restaurants);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Index")]
        public IActionResult Index([FromQuery]GetAllRestaurantsRequest request)
        {
            try
            {
                var restaurants = _restaurantService.GetAllRestaurants(request);
                return Ok(restaurants);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Add")]
        public IActionResult Add(AddRestaurantRequest request)
        {
            try
            {
                _restaurantService.AddRestaurant(request);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpGet("Update")]
        //public IActionResult Update(int id)
        //{
        //    var restaurant = _restaurantService.Get(id);
        //    if (restaurant == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(restaurant);
        //}

        //[HttpPost("Update")]
        //public IActionResult Update(Restaurant restaurant)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _restaurantService.Update(restaurant);
        //        return RedirectToAction("Index");
        //    }
        //    return View(restaurant);
        //}

        [HttpDelete("Delete")]
        public IActionResult Delete(DeleteRestaurantByIdRequest request)
        {
            try
            {
                _restaurantService.DeleteRestaurantById(request);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }
}
