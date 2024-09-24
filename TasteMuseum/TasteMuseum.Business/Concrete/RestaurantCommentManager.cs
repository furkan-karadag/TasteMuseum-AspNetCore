using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteMuseum.Business.Abstract;
using TasteMuseum.Business.Requests.Restaurant;
using TasteMuseum.Business.Requests.RestaurantComment;
using TasteMuseum.DataAccess.Abstract;
using TasteMuseum.Entity.Concreate;

namespace TasteMuseum.Business.Concrete
{
    public class RestaurantCommentManager : IRestaurantCommentService
    {
        private readonly IRestaurantCommentDal _restaurantCommentDal;
        private readonly IRestaurantService _restaurantService;

        public RestaurantCommentManager(IRestaurantCommentDal restaurantCommentDal, IRestaurantService restaurantService)
        {
            _restaurantCommentDal = restaurantCommentDal;
            _restaurantService = restaurantService;
        }

        public void AddRestaurantComment(AddRestaurantCommentRequest request)
        {
            RestaurantComment restaurantComment = new RestaurantComment() { Comment = request.Comment, Date = request.Date, Rating = request.Rating };
            _restaurantCommentDal.Add(restaurantComment);
            Restaurant restaurant = _restaurantService.GetRestaurantById(new GetRestaurantByIdRequest() { Id = request.RestaurantId });
            restaurant.RatingCount++;
            if (restaurant.AverageRating > restaurantComment.Rating)
            {
                restaurant.AverageRating -= (restaurantComment.Rating / restaurant.RatingCount);
            }
            else if (restaurant.AverageRating > restaurantComment.Rating)
            {
                restaurant.AverageRating += (restaurantComment.Rating / restaurant.RatingCount);
            }
        }

        public void DeleteRestaurantComment(DeleteRestaurantCommentRequest request)
        {
            RestaurantComment? restaurantComment = _restaurantCommentDal.Get(rc => rc.Id == request.Id);
            if (restaurantComment == null)
            {
                throw new Exception("RestaurantComment not found");
            }
            _restaurantCommentDal.Delete(restaurantComment);

        }

        public List<RestaurantComment> GetAllRestaurantComments()
        {
            List<RestaurantComment>? restaurantComments = _restaurantCommentDal.GetListAll();
            if (restaurantComments == null || restaurantComments.Count == 0)
            {
                throw new Exception("No RestaurantComment found");

            }
            return restaurantComments.OrderByDescending(rc=>rc.Date).ToList();
        }
    }
}
