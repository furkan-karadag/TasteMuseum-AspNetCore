using Microsoft.AspNetCore.Mvc;
using TasteMuseum.Business.Abstract;
using TasteMuseum.Business.Requests.Food;
using TasteMuseum.Business.Requests.Restaurant;

namespace TasteMuseum.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodController : Controller
    {
        private readonly IFoodService _foodService;

        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }
        [HttpGet("GetFoodsByPrice")]
        public IActionResult GetFoodsByPrice(GetFoodsByPriceRequest request)
        {
            try
            {
                var foods = _foodService.GetFoodsByPrice(request);
                return Ok(foods);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Index")]
        public IActionResult Index([FromQuery]GetAllFoodsRequest request)
        {
            try
            {
                var foods = _foodService.GetAllFoods(request);
                return Ok(foods);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Add")]
        public IActionResult Add(AddFoodRequest request)
        {
            try
            {
                _foodService.AddFood(request);
                return Ok("Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(DeleteFoodByIdRequest request) 
        {
            try
            {
                _foodService.DeleteFoodById(request);
                return Ok("Index");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
