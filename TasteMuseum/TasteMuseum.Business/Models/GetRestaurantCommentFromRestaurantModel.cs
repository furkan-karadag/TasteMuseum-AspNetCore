using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasteMuseum.Business.Models
{
    public class GetRestaurantCommentFromRestaurantModel
    {
        public int Id { get; set; }
        public GetUserFromRestaurantCommentModel  User { get; set; }
    }
}
