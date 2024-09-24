using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteMuseum.Business.Abstract;
using TasteMuseum.Business.Requests.User;
using TasteMuseum.DataAccess.Abstract;
using TasteMuseum.Entity.Concreate;

namespace TasteMuseum.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void AddUser(AddUserRequest request)
        {
            var user = new User() { Name = request.Name, Email = request.Email };
            _userDal.Add(user);
        }

        public void DeleteUserById(DeleteUserByIdRequest request)
        {
            User? user = _userDal.Get(u => u.Id == request.Id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            _userDal.Delete(user);
        }

        public List<User> GetAllUsers()
        {
            List<User>? user = _userDal.GetListAll();
            if (user == null || user.Count == 0)
            {
                throw new Exception("No User found");
            }
            return user;
        }

        public User GetUserById(GetUserIdRequest request)
        {
            User? user = _userDal.Get(u => u.Id == request.Id);
            if (user == null)
            {
                throw new Exception("User not found ");
            }
            return user;
        }

    }
}
