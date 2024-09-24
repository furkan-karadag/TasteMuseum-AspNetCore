using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteMuseum.Business.Requests.Auth;

namespace TasteMuseum.Business.Abstract
{
    public interface IAuthenticationService
    {
        Task<IActionResult>LoginAsync(LoginRequest request);
        Task<IActionResult> RegisterAsync(RegisterRequest request);

    }
}
