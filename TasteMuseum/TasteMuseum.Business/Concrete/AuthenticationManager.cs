using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteMuseum.Business.Abstract;
using TasteMuseum.Business.Requests.Auth;
using TasteMuseum.DataAccess.Abstract;
using TasteMuseum.Entity.Concreate;

namespace TasteMuseum.Business.Concrete
{
    public class AuthenticationManager : IAuthenticationService
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserDal _userDal;

        public AuthenticationManager(IAuthenticationService authenticationService, IUserDal userDal)
        {
            _authenticationService = authenticationService;
            _userDal = userDal;
        }

        Task<IActionResult> IAuthenticationService.LoginAsync(LoginRequest request)
        {
            throw new NotImplementedException();
        }

        Task<IActionResult> IAuthenticationService.RegisterAsync(RegisterRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
