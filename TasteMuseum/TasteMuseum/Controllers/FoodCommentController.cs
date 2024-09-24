using Microsoft.AspNetCore.Mvc;
using TasteMuseum.Business.Abstract;
using TasteMuseum.Business.Requests.FoodComment;
using TasteMuseum.Business.Requests.RestaurantComment;

namespace TasteMuseum.Controllers
{
    public class FoodCommentController : Controller
    {
        private readonly IFoodCommentService _foodCommentService;

        public FoodCommentController(IFoodCommentService foodCommentService)
        {
            _foodCommentService = foodCommentService;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            try
            {
                var foodComments = _foodCommentService.GetAllFoodComments();
                return Ok(foodComments);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Add")]
        public IActionResult AddFoodComment(AddFoodCommentRequest request)
        {
            try
            {
                _foodCommentService.AddFoodComment(request);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete("Delete")]
        public IActionResult DeleteFoodComment(DeleteFoodCommentRequest request) 
        {
            try
            {
                _foodCommentService.DeleteFoodComment(request);
                return RedirectToAction("Index");
            }
            catch (Exception ex )
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
