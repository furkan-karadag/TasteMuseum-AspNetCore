using Microsoft.AspNetCore.Mvc;
using TasteMuseum.Business.Abstract;
using TasteMuseum.Business.Requests.RestaurantComment;

namespace TasteMuseum.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class RestaurantCommentController : Controller
    {
        private readonly IRestaurantCommentService _restaurantCommentService;

        public RestaurantCommentController(IRestaurantCommentService restaurantCommentService)
        {
            _restaurantCommentService = restaurantCommentService;
        }

        [HttpGet("Index")]
        public IActionResult Index() 
        {
            try
            {
                var restaurantComments = _restaurantCommentService.GetAllRestaurantComments();
                return Ok(restaurantComments);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPost("Add")]
        public IActionResult Add(AddRestaurantCommentRequest request)
        {
            try
            {
                _restaurantCommentService.AddRestaurantComment(request);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                
            }
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(DeleteRestaurantCommentRequest request)
        {
            try
            {
                _restaurantCommentService.DeleteRestaurantComment(request);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
