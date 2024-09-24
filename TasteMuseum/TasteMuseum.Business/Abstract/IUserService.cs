using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TasteMuseum.Business.Requests.User;
using TasteMuseum.Entity.Concreate;

namespace TasteMuseum.Business.Abstract
{
    public interface IUserService
    {
        public void AddUser(AddUserRequest request);

        public User GetUserById(GetUserIdRequest request);
        public List<User> GetAllUsers();
        public void DeleteUserById(DeleteUserByIdRequest request);
    }
}
