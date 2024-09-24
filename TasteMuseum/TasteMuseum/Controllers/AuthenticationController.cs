using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Diagnostics;
using TasteMuseum.Business.Abstract;
using TasteMuseum.Business.Requests.Auth;
using TasteMuseum.DataAccess.Concreate;
using TasteMuseum.Entity.Concreate;

namespace TasteMuseum.Controllers
{
    [AllowAnonymous]
    public class AuthenticationController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthenticationController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpGet("Login")]
        public IActionResult Login() 
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Geçersiz e-posta veya parola.");
                return View(request);
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return RedirectToAction("Profile", "Authentication");
            }

           else
            {
                return RedirectToAction("Login", "Authentication");
            }
        }

        [AllowAnonymous]
        [HttpGet("Register")]
        public IActionResult Register() 
        {
            return View(); 
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            User user = new User() { Name = request.Name,Surname=request.Surname, Email = request.Email, UserName = request.UserName};
            if (request.Password != request.ConfirmPassword)
            {
                return View(request);
            }

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(request);
            }

            return RedirectToAction("Login");
        }

        [Authorize]
        [HttpGet("Profile")]
        public async Task<IActionResult> Profile()
        {
            User user = await _userManager.FindByNameAsync(User.Identity?.Name);
            if (user != null)
            {
                var profileRequest = new ProfileRequest
                {
                    Name = user.Name, 
                    Surname = user.Surname, 
                    UserName = user.UserName,
                    PhoneNumber = user.PhoneNumber,
                    Email = user.Email
                };
                return View(profileRequest);
            }
            else
            {
                return NotFound();
            }

        }
        [Authorize]
        [HttpPost("Profile")]
        public async Task <IActionResult>Profile (ProfileRequest request)
        {
            var user = await _userManager.FindByNameAsync(User.Identity?.Name);
            if (request.Picture != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(request.Picture.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/UserImages/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await request.Picture.CopyToAsync(stream);
                user.Image = imagename;
            }
            user.Name = request.Name;
            user.Surname = request.Surname;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, request.Password);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Authentication");
            }
            return View();

        }
    }
}
