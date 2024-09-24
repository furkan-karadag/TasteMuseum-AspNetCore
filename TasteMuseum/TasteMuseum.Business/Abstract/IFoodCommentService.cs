using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteMuseum.Business.Requests.FoodComment;
using TasteMuseum.Entity.Concreate;

namespace TasteMuseum.Business.Abstract
{
    public interface IFoodCommentService
    {
        public void AddFoodComment(AddFoodCommentRequest request);
        public List<FoodComment> GetAllFoodComments();
        public void DeleteFoodComment(DeleteFoodCommentRequest request);
    }
}
