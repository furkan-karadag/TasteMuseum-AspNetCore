using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteMuseum.DataAccess.Abstract;
using TasteMuseum.DataAccess.Concreate;
using TasteMuseum.DataAccess.Repository;
using TasteMuseum.Entity.Concreate;

namespace TasteMuseum.DataAccess.EntityFramework
{
    public class EfFoodCommentDal : GenericRepository<FoodComment>, IFoodCommentDal
    {
        public EfFoodCommentDal()
        {
        }
    }
}
