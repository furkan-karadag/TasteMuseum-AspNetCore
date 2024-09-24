using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteMuseum.Business.Requests.RestaurantComment;
using TasteMuseum.Entity.Concreate;

namespace TasteMuseum.Business.Abstract
{
    public interface IRestaurantCommentService
    {
        public void AddRestaurantComment(AddRestaurantCommentRequest request );

        public List<RestaurantComment> GetAllRestaurantComments();
        public void DeleteRestaurantComment(DeleteRestaurantCommentRequest request);
    }
}
            