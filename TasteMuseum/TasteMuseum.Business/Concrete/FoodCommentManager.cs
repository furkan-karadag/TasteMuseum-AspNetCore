using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteMuseum.Business.Abstract;
using TasteMuseum.Business.Requests.FoodComment;
using TasteMuseum.DataAccess.Abstract;
using TasteMuseum.DataAccess.Repository;
using TasteMuseum.Entity.Concreate;

namespace TasteMuseum.Business.Concrete
{
    public class FoodCommentManager :  IFoodCommentService
    {
        private readonly IFoodCommentDal _foodCommentDal;

        public FoodCommentManager(IFoodCommentDal foodCommentDal)
        {
            _foodCommentDal = foodCommentDal;
        }

        public void AddFoodComment(AddFoodCommentRequest request)
        {
            FoodComment foodComment = new FoodComment() {Comment=request.Comment ,Date=request.Date,Rating=request.Rating};
            _foodCommentDal.Add(foodComment);
        }

        public void DeleteFoodComment(DeleteFoodCommentRequest request)
        {
            FoodComment? foodComment=_foodCommentDal.Get(fc=>fc.Id==request.Id);
            if(foodComment == null)
            {
                throw new Exception("FoodComment not found");
            }
            _foodCommentDal.Delete(foodComment);
        }

        public List<FoodComment> GetAllFoodComments()
        {
            List<FoodComment>? foodComments = _foodCommentDal.GetListAll();
            if (foodComments == null)
            {
                throw new Exception("No FoodCommentFound");
            }
            return foodComments.OrderByDescending(fc=>fc.Date).ToList();
        }
    }
}
